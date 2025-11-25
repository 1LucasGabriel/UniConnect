using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using UniConnect.Domain;
using UniConnect.Domain.Interface.Repository.Repository;
using UniConnect.Domain.Interface.Service;
using UniConnect.Domain.Service;
using UniConnect.Infrastructure.Context;
using UniConnect.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Autenticação JWT (Bearer). " +
                      "Insira 'Bearer' [espaço] e depois o seu token. " +
                      "Exemplo: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"];
if (string.IsNullOrEmpty(secretKey))
{
    throw new InvalidOperationException("JwtSettings:SecretKey não está configurada no appsettings.json...");
}

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidateAudience = true,
        ValidAudience = jwtSettings["Audience"],
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
    };
});
builder.Services.AddAuthorization();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 36))
    )
);

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IPastaEstudoRepository, PastaEstudoRepository>();
builder.Services.AddTransient<IArquivoRepository, ArquivoRepository>();
builder.Services.AddTransient<IDiscussaoRepository, DiscussaoRepository>();
builder.Services.AddTransient<IRespostaRepository, RespostaRepository>();
builder.Services.AddTransient<IDiscussaoReacaoRepository, DiscussaoReacaoRepository>();
builder.Services.AddTransient<IRespostaReacaoRepository, RespostaReacaoRepository>();
builder.Services.AddTransient<IMensagemRepository, MensagemRepository>();

builder.Services.AddTransient<IUsuarioService, UsuarioService>();
builder.Services.AddTransient<IPastaEstudoService, PastaEstudoService>();
builder.Services.AddTransient<IArquivoService, ArquivoService>();
builder.Services.AddTransient<IDiscussaoService, DiscussaoService>();
builder.Services.AddTransient<IRespostaService, RespostaService>();
builder.Services.AddTransient<IDiscussaoReacaoService, DiscussaoReacaoService>();
builder.Services.AddTransient<IRespostaReacaoService, RespostaReacaoService>();
builder.Services.AddTransient<IMensagemService, MensagemService>();
builder.Services.AddTransient<IAuthenticateService, AuthenticateService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
    });
}

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
