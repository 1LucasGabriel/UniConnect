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
    public class RespostaMap : IEntityTypeConfiguration<RespostaEntity>
    {
        public void Configure(EntityTypeBuilder<RespostaEntity> builder)
        {
            builder.ToTable("Resposta");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Conteudo)
                .IsRequired();

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
        }
    }
}
