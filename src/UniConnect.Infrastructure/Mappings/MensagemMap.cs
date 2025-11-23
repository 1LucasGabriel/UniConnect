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
    public class MensagemMap : IEntityTypeConfiguration<MensagemEntity>
    {
        public void Configure(EntityTypeBuilder<MensagemEntity> builder)
        {
            builder.ToTable("Mensagem");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Conteudo)
                .IsRequired();

            builder.Property(x => x.Visualizada)
                .IsRequired();

            builder.HasOne(x => x.UsuarioDestino)
                .WithMany(x => x.MensagensRecebidas)
                .HasForeignKey(x => x.UsuarioDestinoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
