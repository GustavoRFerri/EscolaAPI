using Escola.Application.DTOs.Matricula;
using Escola.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class MatriculaController : Controller
{
    private readonly IMatriculaService _matriculaService;

    public MatriculaController(IMatriculaService matriculaService)
    {
        _matriculaService = matriculaService;
    }


    [HttpPost]
    public async Task<IActionResult> CreateMatricula(MatriculaPostDTO matriculaPostDTO)
    {
        var createdMatricula = await _matriculaService.AddAsync(matriculaPostDTO);
        return Ok(new { message = "Matrícula criada com sucesso.", matricula = createdMatricula });
    }


    [HttpPut("{MatriculaPutDTO}")]
    public async Task<IActionResult> UpdateMatricula(MatriculaPutDTO matriculaPutDTO)
    {
        var updatedMatricula = await _matriculaService.UpdateAsync(matriculaPutDTO);
        return Ok(new { message = "Matrícula atualizada com sucesso.", matricula = updatedMatricula });
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMatricula(int id)
    {
        var deletedMatricula = await _matriculaService.DeleteAsync(id);
        return Ok(new { message = "Matrícula excluída com sucesso." });
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetMatricula(int id)
    {
        var matricula = await _matriculaService.GetByIdAsync(id);
        return Ok(new { message = "Matrícula encontrada com sucesso.", matricula = matricula });
    }


    [HttpGet]
    public async Task<IActionResult> GetAllMatriculas()
    {
        var matriculas = await _matriculaService.GetAllAsync();
        return Ok(new { message = "Matrículas encontradas com sucesso.", matriculas = matriculas });
    }

}
