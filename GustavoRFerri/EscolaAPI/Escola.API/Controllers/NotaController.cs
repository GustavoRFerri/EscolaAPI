using Escola.Application.DTOs.Nota;
using Escola.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotaController : Controller
{
    private readonly INotaService _notaService;

    public NotaController(INotaService notaService)
    {
        _notaService = notaService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateNota(NotaPostDTO notaPostDTO)
    {
        var createdNota = await _notaService.AddAsync(notaPostDTO);      
        return Ok(new { message = "Nota criada com sucesso.", nota = createdNota });
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateNota(NotaPutDTO notaPutDTO)
    {
        var updatedNota = await _notaService.UpdateAsync(notaPutDTO);    
        return Ok(new { message = "Nota atualizada com sucesso.", nota = updatedNota });
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNota(int id)
    {
        var deletedNota = await _notaService.DeleteAsync(id);        
        return Ok(new { message = "Nota excluída com sucesso." });
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetNota(int id)
    {
        var nota = await _notaService.GetByIdAsync(id);      
        return Ok(new { message = "Nota encontrada com sucesso.", nota = nota });
    }


    [HttpGet]
    public async Task<IActionResult> GetAllNotas()
    {
        var notas = await _notaService.GetAllAsync();
        return Ok(new { message = "Notas encontradas com sucesso.", notas = notas });
    }

}
