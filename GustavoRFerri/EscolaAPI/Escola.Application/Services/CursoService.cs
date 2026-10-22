using Escola.Application.DTOs.Curso;
using Escola.Application.DTOs.Interfaces;
using Escola.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Application.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoService(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }




        public Task<CursoGetDTO> AddAsync(CursoPostDTO cursoPostDTO)
        {
            throw new NotImplementedException();
        }

        public Task<CursoGetDTO> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CursoGetDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CursoGetDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CursoGetDTO> UpdateAsync(CursoPutDTO cursoPutDTO)
        {
            throw new NotImplementedException();
        }
    }
}
