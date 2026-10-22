using Escola.Application.DTOs.Turma;
using Escola.Application.DTOs.Usuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Application.Interfaces;

public interface IUsuarioService
{
    Task<UsuarioGetDTO> GetByIdAsync(int id);
    Task<List<UsuarioGetDTO>> GetAllAsync();
    Task<UsuarioGetDTO> AddAsync(UsuarioPostDTO usuarioPostDTO);
    Task<UsuarioGetDTO> UpdateAsync(int id, UsuarioPutDTO usuarioPutDTO);
    Task<UsuarioGetDTO> DeleteAsync(int id);
}
