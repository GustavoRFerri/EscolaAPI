using Escola.Application.DTOs.Usuario;
using Escola.Application.Interfaces;
using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Escola.Application.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<UsuarioGetDTO> AddAsync(UsuarioPostDTO usuarioPostDTO)
    {
        using var hmac = new HMACSHA512();
        byte[] senhaHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(usuarioPostDTO.Senha));
        byte[] senhaSalt = hmac.Key;

        var usuario = new Usuario
        {
            Nome = usuarioPostDTO.Nome,
            Email = usuarioPostDTO.Email,
            PasswordHash = senhaHash,
            PasswordSalt = senhaSalt,
            Perfil = "Usuario",
        };

        var usuarioGetDTO = await _usuarioRepository.AddAsync(usuario);
        return new UsuarioGetDTO
        {
            Id = usuarioGetDTO.Id,
            Nome = usuarioGetDTO.Nome,
            Email = usuarioGetDTO.Email
        };
    }

   

    public async Task<UsuarioGetDTO> DeleteAsync(int id)
    {
        var deleteUsuario = await _usuarioRepository.DeleteAsync(id);
        if (deleteUsuario == null)
        {
            throw new Exception("Usuário não encontrado.");
        }
        return  new UsuarioGetDTO
        {
            Id = deleteUsuario.Id,
            Nome = deleteUsuario.Nome,
            Email = deleteUsuario.Email
        };

    }

    public async Task<List<UsuarioGetDTO>> GetAllAsync()
    {
        var usuarios = await _usuarioRepository.GetAllAsync();
        var usuarioGetDTOs = new List<UsuarioGetDTO>();
        foreach (var usuario in usuarios)
        {
            usuarioGetDTOs.Add(new UsuarioGetDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email
            });
        }
        return usuarioGetDTOs;
    }


    public async Task<UsuarioGetDTO> GetByIdAsync(int id)
    {
        var usuario = await _usuarioRepository.GetByIdAsync(id);
        if (usuario == null)
        {
            throw new Exception("Usuário não encontrado.");
        }
        return new UsuarioGetDTO
        {
            Id = usuario.Id,
            Nome = usuario.Nome,
            Email = usuario.Email
        };
    }



    public async Task<UsuarioGetDTO> UpdateAsync(int id, UsuarioPutDTO usuarioPutDTO)
    {
        var usuario = await _usuarioRepository.GetByIdAsync(id);
        if (usuario == null)
        {
            throw new Exception("Usuário não encontrado.");
        }

        usuario.Nome = usuarioPutDTO.Nome;
        usuario.Email = usuarioPutDTO.Email;

        var updatedUsuario = await _usuarioRepository.UpdateAsync(usuario);
        return new UsuarioGetDTO
        {
            Id = updatedUsuario.Id,
            Nome = updatedUsuario.Nome,
            Email = updatedUsuario.Email
        };
    }
}
