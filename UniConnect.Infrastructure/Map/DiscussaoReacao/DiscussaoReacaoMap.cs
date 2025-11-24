using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniConnect.Domain.Entity;

namespace UniConnect.Infrastructure.Mappings
{
    public class DiscussaoReacaoMap : IEntityTypeConfiguration<DiscussaoReacao>
    {
        public void Configure(EntityTypeBuilder<DiscussaoReacao> builder)
        {
            builder.ToTable("discussao_reacao");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Tipo).IsRequired();

            builder.Property(x => x.DataCriacao)
                .IsRequired();
            builder.Property(x => x.DataAlteracao);

            builder.HasOne(x => x.Discussao)
                .WithMany(x => x.Reacoes)
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
