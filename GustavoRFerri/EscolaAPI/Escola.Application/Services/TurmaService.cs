using Escola.Application.DTOs.Curso;
using Escola.Application.DTOs.Nota;
using Escola.Application.DTOs.Turma;
using Escola.Application.Exceptions;
using Escola.Application.Interfaces;
using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Application.Services
{
    public class TurmaService : ITurmaService
    {
        private readonly ITurmaRepository _turmaRepository;
        private readonly ICursoRepository _cursoRepository;

        public TurmaService(ITurmaRepository turmaRepository, ICursoRepository cursoRepository)
        {
            _turmaRepository = turmaRepository; 
            _cursoRepository = cursoRepository;
        }


        public async Task<TurmaGetDTO> AddAsync(TurmaPostDTO turmaPostDTO)
        {

            var curso = await _cursoRepository.GetByIdAsync(turmaPostDTO.CursoId);
            if (curso == null)
            {
                throw new NotFoundException($"Curso com ID {turmaPostDTO.CursoId} não encontrado.");
            }

            var turma = new Turma
            {
                CursoId = turmaPostDTO.CursoId,
                Descricao = turmaPostDTO.Descricao,
                Nome = turmaPostDTO.Nome
            };
            var result = await _turmaRepository.AddAsync(turma);
            return new TurmaGetDTO
            {
                Id = result.Id,
                Nome = result.Nome,
                Descricao = result.Descricao,
                CursoId = result.CursoId
            };

        }

        public async Task<TurmaGetDTO> DeleteAsync(int id)
        {
            var deletedTurma = await _turmaRepository.GetByIdAsync(id);
            if (deletedTurma == null)            
                throw new NotFoundException($"Turma com ID {id} não encontrada.");

            await _turmaRepository.DeleteAsync(deletedTurma.Id);
            return new TurmaGetDTO
            {
                Id = deletedTurma.Id,
                Nome = deletedTurma.Nome,
                Descricao = deletedTurma.Descricao,
                CursoId = deletedTurma.CursoId                 
            };
        }

        public async Task<List<TurmaGetDetailDTO>> GetAllAsync()
        {
            var turmas = await _turmaRepository.GetAllAsync();
            var turmaGetDetailDTOs = new List<TurmaGetDetailDTO>();

            turmaGetDetailDTOs.AddRange(turmas.Select(turma => new TurmaGetDetailDTO
            {
                Id = turma.Id,
                Nome = turma.Nome,
                Descricao = turma.Descricao,
                Curso = new CursoGetDTO
                {
                    Id = turma.Curso.Id,
                    Nome = turma.Curso.Nome,
                    Descricao = turma.Curso.Descricao
                }
            }));

            return turmaGetDetailDTOs;

        }

        public async Task<TurmaGetDetailDTO> GetByIdAsync(int id)
        {
            var turma = await _turmaRepository.GetByIdAsync(id);
            
            if (turma == null)            
                throw new NotFoundException($"Turma com ID {id} não encontrada.");            

            return new TurmaGetDetailDTO
            {
                Id = turma.Id,
                Nome = turma.Nome,
                Descricao = turma.Descricao,
                Curso = new CursoGetDTO
                {
                    Id = turma.Curso.Id,
                    Nome = turma.Curso.Nome,
                    Descricao = turma.Curso.Descricao
                }
            };
        }

        public async Task<TurmaGetDTO> UpdateAsync(TurmaPutDTO turmaPutDTO)
        {
            var existingTurma = await _turmaRepository.GetByIdAsync(turmaPutDTO.Id);
            if (existingTurma == null)            
                throw new NotFoundException($"Turma com ID {turmaPutDTO.Id} não encontrada.");
            

            var curso = await _cursoRepository.GetByIdAsync(turmaPutDTO.CursoId);
            if (curso == null)            
                throw new NotFoundException($"Curso com ID {turmaPutDTO.CursoId} não encontrado.");

            var turma = new Turma
            {
                Id = turmaPutDTO.Id,
                Nome = turmaPutDTO.Nome,
                Descricao = turmaPutDTO.Descricao,
                CursoId = turmaPutDTO.CursoId
            };
            var result = await   _turmaRepository.UpdateAsync(turma);

            if (result == null)            
                throw new Exception("Turma não encontrada.");

            return new TurmaGetDTO
            {
                Id = result.Id,
                Nome = result.Nome,
                Descricao = result.Descricao,
                CursoId = result.CursoId
            };

        }
    }
}
