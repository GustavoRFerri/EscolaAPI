using Escola.Application.DTOs.Matricula;
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

public class MatriculaService : IMatriculaService
{
    private readonly IMatriculaRepository _matriculaRepository;
    private readonly ITurmaService _turmaService;
    private readonly IUsuarioService _usuarioService;


    public MatriculaService(IMatriculaRepository matriculaRepository, ITurmaService turmaService, IUsuarioService usuarioService    )
    {
        _matriculaRepository = matriculaRepository;
        _turmaService = turmaService;
        _usuarioService = usuarioService;
    }

    public Task<MatriculaGetDTO> AddAsync(MatriculaPostDTO matriculaPostDTO)
    {
        var usuario = _usuarioService.GetByIdAsync(matriculaPostDTO.UsuarioId).Result;
        var turma = _turmaService.GetByIdAsync(matriculaPostDTO.TurmaId).Result;

        if (turma == null)        
            throw new NotFoundException($"Turma não encontrados.");        

        if (usuario == null)        
            throw new NotFoundException($"Usuário não encontrados.");       


        var matricula = new Matricula
        {
            UsuarioId = matriculaPostDTO.UsuarioId,
            TurmaId = matriculaPostDTO.TurmaId,
            DataMatricula = DateTime.Now,
            DataExpiracao = matriculaPostDTO.DataExpiracao,
            Ativa = true
        };
        var result = _matriculaRepository.AddAsync(matricula);
        return Task.FromResult(new MatriculaGetDTO
        {
            Id = matricula.Id,
            UsuarioId = matricula.UsuarioId,
            TurmaId = matricula.TurmaId,
            DataMatricula = matricula.DataMatricula,
            DataExpiracao = matricula.DataExpiracao,
            Ativa = matricula.Ativa
        });
    }

    public async Task<MatriculaGetDTO> DeleteAsync(int id)
    {
        var deletedMatricula = await _matriculaRepository.DeleteAsync(id);

        if (deletedMatricula == null)        
            throw new NotFoundException("Matrícula não encontrada.");
        
        
        return new MatriculaGetDTO
        {
            Id = deletedMatricula.Id,
            UsuarioId = deletedMatricula.UsuarioId,
            TurmaId = deletedMatricula.TurmaId,
            DataMatricula = deletedMatricula.DataMatricula,
            DataExpiracao = deletedMatricula.DataExpiracao,
            Ativa = deletedMatricula.Ativa
        };
    }

    public Task<List<MatriculaGetDetailDTO>> GetAllAsync()
    {
        var matriculas = _matriculaRepository.GetAllAsync();
        var matriculaGetDTOs = new List<MatriculaGetDetailDTO>();
        foreach (var matricula in matriculas.Result)
        {
            matriculaGetDTOs.Add(new MatriculaGetDetailDTO
            {
                Id = matricula.Id,               
                
                DataMatricula = matricula.DataMatricula,
                DataExpiracao = matricula.DataExpiracao,
                Ativa = matricula.Ativa,
                Usuario = new UsuarioGetDTO
                {
                    Id = matricula.Usuario.Id,
                    Nome = matricula.Usuario.Nome,
                    Email = matricula.Usuario.Email
                },
                Turma = new TurmaGetDTO
                {
                    Id = matricula.Turma.Id,
                    Nome = matricula.Turma.Nome,
                    Descricao = matricula.Turma.Descricao
                }
            });
        }
        return Task.FromResult(matriculaGetDTOs);

    }

    public async Task<MatriculaGetDetailDTO> GetByIdAsync(int id)
    {
        var matricula = await _matriculaRepository.GetByIdAsync(id);
        if (matricula == null)        
            throw new NotFoundException("Matrícula não encontrada.");
          
        return new MatriculaGetDetailDTO
        {
            Id = matricula.Id,
            DataMatricula = matricula.DataMatricula,
            DataExpiracao = matricula.DataExpiracao,
            Ativa = matricula.Ativa,
            Usuario = new UsuarioGetDTO
            {
                Id = matricula.Usuario.Id,
                Nome = matricula.Usuario.Nome,
                Email = matricula.Usuario.Email
            },
            Turma = new TurmaGetDTO
            {
                Id = matricula.Turma.Id,
                Nome = matricula.Turma.Nome,
                Descricao = matricula.Turma.Descricao
            }            
        };
    }

    public async Task<MatriculaGetDTO> UpdateAsync(MatriculaPutDTO matriculaPutDTO)
    { 
        var matriculaExistente = await _matriculaRepository.GetByIdAsync(matriculaPutDTO.Id);
        if (matriculaExistente == null)
            throw new NotFoundException($"Matrícula não encontrada.");

        var turma = _turmaService.GetByIdAsync(matriculaPutDTO.TurmaId).Result;
        if (turma == null)
            throw new NotFoundException($"Turma não encontrados.");

        var matricula = new Matricula
        {
            Id = matriculaPutDTO.Id,            
            TurmaId = matriculaPutDTO.TurmaId,
            DataExpiracao = matriculaPutDTO.DataExpiracao            
        };

        var result = await _matriculaRepository.UpdateAsync(matricula);
        if (result == null)        
            throw new NotFoundException("Matrícula não encontrada.");        

        return new MatriculaGetDTO
        {
            Id = matricula.Id,
            UsuarioId = matricula.UsuarioId,
            TurmaId = matricula.TurmaId,
            DataMatricula = matricula.DataMatricula,
            DataExpiracao = matricula.DataExpiracao,
            Ativa = matricula.Ativa
        };
    }

}
