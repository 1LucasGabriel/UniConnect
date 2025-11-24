using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UniConnect.Argument.Argument;
using UniConnect.Domain.Entity;
using UniConnect.Domain.Interface.Repository.Repository;
using UniConnect.Domain.Interface.Service;

namespace UniConnect.Domain.Service;

public class AuthenticateService : IAuthenticateService
{
    private readonly IConfiguration _configuration;
    private readonly IUsuarioRepository _usuarioRepository;

    public AuthenticateService(IConfiguration configuration, IUsuarioRepository usuarioRepository)
    {
        _configuration = configuration;
        _usuarioRepository = usuarioRepository;
    }

    public OutputAuthenticate Authenticate(InputAuthenticate inputAuthenticate)
    {
        Usuario? usuario = _usuarioRepository.GetByEmail(inputAuthenticate.Email);
        if (usuario == null)
            throw new KeyNotFoundException("Usuário não existente");

        if (!string.Equals(usuario.Senha, inputAuthenticate.Senha, StringComparison.Ordinal))
            throw new Exception("Senha inválida");

        return new OutputAuthenticate(GenerateToken(usuario));
    }

    #region Private
    private string GenerateToken(Usuario usuario)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var secretKey = jwtSettings["SecretKey"];
        var issuer = jwtSettings["Issuer"];
        var audience = jwtSettings["Audience"];

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
            new Claim(ClaimTypes.Role, "Admin"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials);

        var tokenHandler = new JwtSecurityTokenHandler();
        string stringToken = tokenHandler.WriteToken(token);

        return stringToken;
    }
    #endregion
}
