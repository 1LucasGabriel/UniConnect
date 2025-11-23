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
    public class DiscussaoMap : IEntityTypeConfiguration<DiscussaoEntity>
    {
        public void Configure(EntityTypeBuilder<DiscussaoEntity> builder)
        {
            builder.ToTable("Discussao");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Titulo)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Conteudo)
                .IsRequired();

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
        }
    }
}
