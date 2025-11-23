using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniConnect.Application.DTOs;
using UniConnect.Domain.Entities;

namespace UniConnect.Application.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<UsuarioEntity>> Buscar();
        Task<UsuarioEntity> BuscarPorId(int id);
        Task<UsuarioDTO> Criar(UsuarioDTO usuario);
        Task<UsuarioEntity> Atualizar(int id, UsuarioEntity usuario);
        Task<bool> Deletar(int id);
    }
}
