using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniConnect.Application.DTOs;
using UniConnect.Application.Services.Interfaces;
using UniConnect.Domain.Entities;
using UniConnect.Domain.Enums;
using UniConnect.Domain.Interfaces;

namespace UniConnect.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<UsuarioEntity>> Buscar()
        {
            return await _repository.Buscar();
        }

        public async Task<UsuarioEntity> BuscarPorId(int id)
        {
            return await _repository.BuscarPorId(id);
        }

        public async Task<UsuarioDTO> Criar(UsuarioDTO usuario)
        {
            var entity = new UsuarioEntity
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
                Senha = usuario.Senha,
                FotoPerfilUrl = usuario.FotoPerfilUrl,
                TipoUsuario = usuario.TipoUsuario
            };

            await _repository.Adicionar(entity);

            return usuario;
        }

        public async Task<UsuarioEntity> Atualizar(int id, UsuarioEntity usuario)
        {
            await _repository.Atualizar(id, usuario);
            return usuario;
        }

        public async Task<bool> Deletar(int id)
        {
            var usuario = await _repository.BuscarPorId(id);

            if (usuario == null)
                return false;

            await _repository.Deletar(id);
            return true;
        }
    }
}
