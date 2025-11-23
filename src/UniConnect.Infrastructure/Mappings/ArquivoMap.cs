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
    public class ArquivoMap : IEntityTypeConfiguration<ArquivoEntity>
    {
        public void Configure(EntityTypeBuilder<ArquivoEntity> builder)
        {
            builder.ToTable("Arquivo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Tipo)
                .HasMaxLength(30);

            builder.Property(x => x.Url)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.TamanhoBytes).IsRequired();

            builder.HasOne(x => x.PastaEstudo)
                .WithMany(x => x.Arquivos)
                .HasForeignKey(x => x.PastaEstudoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
