using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniConnect.Domain.Entity;

namespace UniConnect.Infrastructure.Mappings
{
    public class RespostaMap : IEntityTypeConfiguration<Resposta>
    {
        public void Configure(EntityTypeBuilder<Resposta> builder)
        {
            builder.ToTable("resposta");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Conteudo)
                .IsRequired();

            builder.Property(x => x.DataCriacao)
                .IsRequired();
            builder.Property(x => x.DataAlteracao);

            builder.HasOne(x => x.RespostaPai)
                .WithMany(x => x.SubRespostas)
                .HasForeignKey(x => x.RespostaPaiId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Discussao)
                .WithMany(x => x.Respostas)
                .HasForeignKey(x => x.DiscussaoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Reacoes)
                .WithOne(x => x.Resposta)
                .HasForeignKey(x => x.RespostaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.UsuarioCriacao)
               .WithMany()
               .HasForeignKey(x => x.UsuarioCriacaoId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.UsuarioAlteracao)
                .WithMany()
                .HasForeignKey(x => x.UsuarioAlteracaoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
