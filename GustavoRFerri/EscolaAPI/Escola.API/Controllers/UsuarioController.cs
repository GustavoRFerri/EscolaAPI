using   Escola.Application.DTOs.Curso;
using Escola.Application.DTOs.Usuario;
using Escola.Application.Interfaces;
using Escola.Application.Services;
using Escola.Domain.Account;
using Escola.Domain.Entities;
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
        var createdUser = await _usuarioService.AddAsync(usuarioPostDTO);   
        
       var token = 

        return Ok(new { message = "Usuário criado com sucesso.", Usuario = createdUser });
    }

           
    
}
