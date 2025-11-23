using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniConnect.Domain.Entities;

namespace UniConnect.Infrastructure.Mappings
{
    public class DiscussaoReacaoMap : IEntityTypeConfiguration<DiscussaoReacaoEntity>
    {
        public void Configure(EntityTypeBuilder<DiscussaoReacaoEntity> builder)
        {
            builder.ToTable("DiscussaoReacao");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Tipo).IsRequired();

            builder.HasOne(x => x.Discussao)
                .WithMany(x => x.Reacoes)
                .HasForeignKey(x => x.DiscussaoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Usuario)
                .WithMany()
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.UsuarioAlteracao)
                .WithMany()
                .HasForeignKey(x => x.UsuarioAlteracaoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
