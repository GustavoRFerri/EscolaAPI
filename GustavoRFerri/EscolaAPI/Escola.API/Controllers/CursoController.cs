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
        return Ok(new { message = "Curso criado com sucesso.", curso = createdCurso });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCurso(CursoPutDTO cursoPutDTO)
    {
        var updatedCurso = await _cursoService.UpdateAsync(cursoPutDTO);        
        return Ok(new { message = "Curso atualizado com sucesso.", curso = updatedCurso });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCurso(int id)
    {
        var deletedCurso = await _cursoService.DeleteAsync(id);   
        return Ok(new { message = "Curso excluído com sucesso." });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCurso(int id)
    {
        var curso = await _cursoService.GetByIdAsync(id);       
        return Ok(curso);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCursos()
    {
        var cursos = await _cursoService.GetAllAsync();
        return Ok(cursos);
    }

}
