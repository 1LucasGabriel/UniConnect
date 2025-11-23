using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniConnect.Domain.Entities;

namespace UniConnect.Infrastructure.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<UsuarioEntity> Usuarios { get; set; }
        public DbSet<PastaEstudoEntity> PastasEstudo { get; set; }
        public DbSet<ArquivoEntity> Arquivos { get; set; }
        public DbSet<DiscussaoEntity> Discussoes { get; set; }
        public DbSet<RespostaEntity> Respostas { get; set; }
        public DbSet<DiscussaoReacaoEntity> DiscussaoReacoes { get; set; }
        public DbSet<RespostaReacaoEntity> RespostaReacoes { get; set; }
        public DbSet<MensagemEntity> Mensagens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
