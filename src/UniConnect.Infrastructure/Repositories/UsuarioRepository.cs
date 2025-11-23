using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniConnect.Domain.Entities;
using UniConnect.Domain.Interfaces;
using UniConnect.Infrastructure.Context;

namespace UniConnect.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;
        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Adicionar(UsuarioEntity usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(int id, UsuarioEntity usuario)
        {
            var usuarioExistente = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);

            if (usuarioExistente == null)
                return;

            usuarioExistente.Nome = usuario.Nome;
            usuarioExistente.Email = usuario.Email;
            usuarioExistente.Telefone = usuario.Telefone;
            usuarioExistente.FotoPerfilUrl = usuario.FotoPerfilUrl;
            usuarioExistente.TipoUsuario = usuario.TipoUsuario;
            usuarioExistente.UsuarioAlteracaoId = usuario.UsuarioAlteracaoId;
            usuarioExistente.DataAlteracao = DateTime.Now;

            await _context.SaveChangesAsync();
        }

        public async Task<List<UsuarioEntity>> Buscar()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<UsuarioEntity> BuscarPorId(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task Deletar(int id)
        {
            var usuario = await BuscarPorId(id);
            if (usuario == null) return;

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
