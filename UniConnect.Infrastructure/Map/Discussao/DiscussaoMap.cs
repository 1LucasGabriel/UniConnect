using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniConnect.Domain.Entity;

namespace UniConnect.Infrastructure.Mappings
{
    public class DiscussaoMap : IEntityTypeConfiguration<Discussao>
    {
        public void Configure(EntityTypeBuilder<Discussao> builder)
        {
            builder.ToTable("discussao");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Titulo)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Conteudo)
                .IsRequired();

            builder.Property(x => x.DataCriacao)
                .IsRequired();
            builder.Property(x => x.DataAlteracao);

            builder.HasOne(x => x.DiscussaoPai)
                .WithMany(x => x.SubDiscussoes)
                .HasForeignKey(x => x.DiscussaoPaiId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Respostas)
                .WithOne(x => x.Discussao)
                .HasForeignKey(x => x.DiscussaoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Reacoes)
                .WithOne(x => x.Discussao)
                .HasForeignKey(x => x.DiscussaoId)
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
