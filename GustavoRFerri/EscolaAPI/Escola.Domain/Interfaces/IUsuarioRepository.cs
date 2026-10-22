using Escola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetByIdAsync(int id);
        //Task<IEnumerable<Curso>> GetAllAsync();
        Task<List<Usuario>> GetAllAsync();
        Task<Usuario> AddAsync(Usuario nota);
        Task<Usuario> UpdateAsync(Usuario nota);
        Task<Usuario> DeleteAsync(int id);
    }
}
