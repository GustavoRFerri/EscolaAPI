using Escola.Application.DTOs.Curso;
using Escola.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers;



[ApiController]
[Route("api/[controller]")]
public class CursoController : Controller
{
    private readonly ICursoService _cursoService;

    public CursoController(ICursoService cursoService)
    {
        _cursoService = cursoService;
    }


    [HttpPost]
    public async Task<IActionResult> CreateCurso(CursoPostDTO cursoPostDTO)
    {
        var createdCurso = await _cursoService.AddAsync(cursoPostDTO);
        if (createdCurso == null)
            return BadRequest("Não foi possível criar o curso.");
        return Ok(new { message = "Curso criado com sucesso.", curso = createdCurso });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCurso(CursoPutDTO cursoPutDTO)
    {
        var updatedCurso = await _cursoService.UpdateAsync(cursoPutDTO);
        if (updatedCurso == null)
            return BadRequest("Não foi possível atualizar o curso.");
        return Ok(new { message = "Curso atualizado com sucesso.", curso = updatedCurso });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCurso(int id)
    {
        var deletedCurso = await _cursoService.DeleteAsync(id);
        if (deletedCurso == null)
            return BadRequest("Não foi possível excluir o curso.");
        return Ok(new { message = "Curso excluído com sucesso." });
    }


}
