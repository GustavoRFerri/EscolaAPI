using Escola.Application.DTOs.Matricula;
using Escola.Application.DTOs.Nota;
using Escola.Application.DTOs.Turma;
using Escola.Application.DTOs.Usuario;
using Escola.Application.Exceptions;
using Escola.Application.Interfaces;
using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Application.Services;

public class NotaService : INotaService
{
    private readonly INotaRepository _notaRepository;
    private readonly IMatriculaService _matriculaService;

    public NotaService(INotaRepository notaRepository, IMatriculaService matriculaService)
    {
        _notaRepository = notaRepository;
        _matriculaService = matriculaService;
    }

    public async Task<NotaGetDTO> AddAsync(NotaPostDTO notaPostDTO)
    {        
        if (await _matriculaService.GetByIdAsync(notaPostDTO.MatriculaId) == null)        
            throw new NotFoundException("Matrícula não encontrada.");

        var nota = new Nota
        {
            MatriculaId = notaPostDTO.MatriculaId,           
            DataNota = DateTime.Now
        };
        var result = _notaRepository.AddAsync(nota);
        return new NotaGetDTO
        {
            Id = nota.Id,
            MatriculaId = nota.MatriculaId,            
            DataNota = nota.DataNota
        };
    }

    public async Task<NotaGetDTO> DeleteAsync(int id)
    {
        var deletedNota = await _notaRepository.DeleteAsync(id);

        if (deletedNota == null)        
            throw new NotFoundException("Nota não encontrada.");        

        return new NotaGetDTO
        {
            Id = deletedNota.Id,
            MatriculaId = deletedNota.MatriculaId,
            DataNota = deletedNota.DataNota
        };        
    }



    public async Task<List<NotaGetDTO>> GetAllAsync()
    {
        var notas = await _notaRepository.GetAllAsync();
        var notaGetDTOs = new List<NotaGetDTO>();
        foreach (var nota in notas)
        {
            notaGetDTOs.Add(new NotaGetDTO
            {
                Id = nota.Id,
                MatriculaId = nota.MatriculaId,
                DataNota = nota.DataNota
            });
        }
        return (notaGetDTOs);
    }

    public async Task<NotaGetDTO> GetByIdAsync(int id)
    {
        var nota = await _notaRepository.GetByIdAsync(id);
        if (nota == null)        
            throw new NotFoundException("Nota não encontrada.");        

        return new NotaGetDTO
        {
            Id = nota.Id,
            MatriculaId = nota.MatriculaId,
            DataNota = nota.DataNota
        };
    }

    public async Task<NotaGetDTO> UpdateAsync(NotaPutDTO notaPutDTO)
    {
        var existingNota = _notaRepository.GetByIdAsync(notaPutDTO.Id).Result;
        if (existingNota == null)
            throw new NotFoundException("Nota não encontrada.");


        if (notaPutDTO.MatriculaId != existingNota.MatriculaId)
        {            
            if (await _matriculaService.GetByIdAsync(notaPutDTO.MatriculaId) == null)
                throw new NotFoundException("Matrícula não encontrada.");

            existingNota.MatriculaId = notaPutDTO.MatriculaId;
        }

        existingNota.ValorNota = notaPutDTO.ValorNota;
        existingNota.Aprovado = notaPutDTO.ValorNota >= 60; // Assuming 6 is the passing grade
        var updatedNota = await _notaRepository.UpdateAsync(existingNota);

        return new NotaGetDTO   
        {
            Id = updatedNota.Id,
            MatriculaId = updatedNota.MatriculaId,
            ValorNota = updatedNota.ValorNota,
            Aprovado = updatedNota.Aprovado,
            DataNota = updatedNota.DataNota
        };
    }
}

           
        
    

