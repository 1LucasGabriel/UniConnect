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
    public class PastaEstudoMap : IEntityTypeConfiguration<PastaEstudoEntity>
    {
        public void Configure(EntityTypeBuilder<PastaEstudoEntity> builder)
        {
            builder.ToTable("PastaEstudo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Titulo).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Descricao).HasMaxLength(500);
            builder.Property(x => x.Visibilidade).IsRequired();

            builder.HasOne(x => x.PastaPai)
                .WithMany(x => x.SubPastas)
                .HasForeignKey(x => x.PastaEstudoPaiId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Arquivos)
                .WithOne(x => x.PastaEstudo)
                .HasForeignKey(x => x.PastaEstudoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
