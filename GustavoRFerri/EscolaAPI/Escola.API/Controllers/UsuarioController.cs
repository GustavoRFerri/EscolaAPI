using Escola.Application.DTOs.Curso;
using Escola.Application.DTOs.Usuario;
using Escola.Application.Interfaces;
using Escola.Application.Services;
using Escola.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : Controller
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }


    [HttpPost]
    public async Task<IActionResult> CreateCurso(UsuarioPostDTO usuarioPostDTO)
    {
        var createdUser = await _usuarioService.AddAsync(usuarioPostDTO);
        return Ok(new { message = "Usuário criado com sucesso.", Usuario = createdUser });
    }
}
