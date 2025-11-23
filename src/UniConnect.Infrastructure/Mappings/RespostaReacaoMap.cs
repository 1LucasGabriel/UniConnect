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
    public class RespostaReacaoMap : IEntityTypeConfiguration<RespostaReacaoEntity>
    {
        public void Configure(EntityTypeBuilder<RespostaReacaoEntity> builder)
        {
            builder.ToTable("RespostaReacao");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Tipo).IsRequired();

            builder.HasOne(x => x.Resposta)
                .WithMany(x => x.Reacoes)
                .HasForeignKey(x => x.RespostaId)
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
