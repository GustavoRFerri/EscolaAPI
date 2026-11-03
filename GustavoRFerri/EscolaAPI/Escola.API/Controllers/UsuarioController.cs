using Escola.API.Models;
using   Escola.Application.DTOs.Curso;
using Escola.Application.DTOs.Usuario;
using Escola.Application.Interfaces;
using Escola.Application.Services;
using Escola.Domain.Account;
using Escola.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Escola.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : Controller
{
    private readonly IUsuarioService _usuarioService;
    private readonly IAuthenticate _authenticate;

    public UsuarioController(IUsuarioService usuarioService, IAuthenticate authenticate)
    {
        _usuarioService = usuarioService;
        _authenticate = authenticate;
    }

    
    [HttpPost]
    public async Task<IActionResult> CreateCurso(UsuarioPostDTO usuarioPostDTO)
    {
        var usuario = await _usuarioService.AddAsync(usuarioPostDTO);
        var token = _authenticate.GenerateToken(usuario.Id, usuario.Email.ToLower(), usuario.Perfil);
        return Ok(new { Token = token, Usuario = usuario, message = "Usuário criado com sucesso.",  });
    }


    //[HttpGet]
    //public async Task<IActionResult> GetTokenUsuario(UsuarioPostDTO usuarioPostDTO)
    //{
    //    var usuario = await _usuarioService.AddAsync(usuarioPostDTO);
    //    var token = _authenticate.GenerateToken(usuario.Id, usuario.Email.ToLower(), usuario.Perfil);
    //    return Ok(new { Token = token, Usuario = usuario, message = "Usuário criado com sucesso.", });
    //}


    [HttpGet]
    public async Task<IActionResult> GetTokenUsuario(UserLogin usuarioLogin)
    {
        var usuario = await _authenticate.GetUsuarioByEmail(usuarioLogin.Email);
        if (usuario == null)
            return BadRequest(new { message = "Usuário ou senha incorretos." });

        var usuarioValido = await _authenticate.AuthenticateAsync(usuarioLogin.Email, usuarioLogin.Senha);
        if (!usuarioValido)
            return BadRequest(new { message = "Usuário ou senha incorretos." });

        var token = _authenticate.GenerateToken(usuario.Id, usuario.Email.ToLower(), usuario.Perfil);
        return Ok(new { Token = token, Usuario = usuario, message = "Usuário criado com sucesso.", });
    }




    [HttpGet("Rota-de-teste")]
    [Authorize(Roles ="Administrador")]
    public async Task<ActionResult> Teste()
    {
        return Ok(new { message = "Usuário Logado" });
    }
    
}
