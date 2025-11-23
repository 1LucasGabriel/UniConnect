using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniConnect.Domain.Entities;

namespace UniConnect.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<UsuarioEntity>> Buscar();
        Task<UsuarioEntity> BuscarPorId(int id);
        Task Adicionar(UsuarioEntity usuario);
        Task Atualizar(int id, UsuarioEntity usuario);
        Task Deletar(int id);
    }
}
