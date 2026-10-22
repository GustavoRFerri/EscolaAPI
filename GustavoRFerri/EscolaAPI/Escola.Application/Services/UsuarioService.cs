using Escola.Application.DTOs.Usuario;
using Escola.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Application.Services;

public class UsuarioService : IUsuarioService
{
    public Task<UsuarioGetDTO> AddAsync(UsuarioPostDTO usuarioPostDTO)
    {
        throw new NotImplementedException();
    }

    public Task<UsuarioGetDTO> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<UsuarioGetDTO>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UsuarioGetDTO> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<UsuarioGetDTO> UpdateAsync(int id, UsuarioPutDTO usuarioPutDTO)
    {
        throw new NotImplementedException();
    }
}
