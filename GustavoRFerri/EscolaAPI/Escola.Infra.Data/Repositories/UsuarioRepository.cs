using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Infra.Data.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    public Task<Usuario> AddAsync(Usuario nota)
    {
        throw new NotImplementedException();
    }

    public Task<Usuario> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Usuario>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Usuario> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Usuario> UpdateAsync(Usuario nota)
    {
        throw new NotImplementedException();
    }
}
