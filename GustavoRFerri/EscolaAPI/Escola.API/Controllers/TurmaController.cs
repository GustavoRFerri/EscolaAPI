using Escola.Application.DTOs.Turma;
using Escola.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TurmaController : Controller
{
    private readonly ITurmaService _turmaService;

    public TurmaController(ITurmaService turmaService)
    {
        _turmaService = turmaService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTurma(TurmaPostDTO turmaPostDTO)
    {
        var createdTurma = await _turmaService.AddAsync(turmaPostDTO);

        if (createdTurma == null)        
            return BadRequest("Não foi possível criar a turma.");        

        return Ok(new { message = "Turma criada com sucesso.", turma = createdTurma });
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTurma(TurmaPutDTO turmaPutDTO)
    {
        var updatedTurma = await _turmaService.UpdateAsync(turmaPutDTO);

        if (updatedTurma == null)
            return BadRequest("Não foi possível atualizar a turma.");

        return Ok(new { message = "Turma atualizada com sucesso.", turma = updatedTurma });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTurma(int id)
    {
        var deleted = await _turmaService.DeleteAsync(id);
        if (deleted == null)        
            return BadRequest("Não foi possível excluir a turma.");        

        return Ok(new { message = "Turma excluída com sucesso." });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTurmaById(int id)
    {
        var turma = await _turmaService.GetByIdAsync(id);
        if (turma == null)
            return NotFound("Turma não encontrada.");

        return Ok(turma);
    }


    [HttpGet]
    public async Task<IActionResult> GetAllTurmas()
    {
        var turmas = await _turmaService.GetAllAsync();
        return Ok(turmas);
    }

}
