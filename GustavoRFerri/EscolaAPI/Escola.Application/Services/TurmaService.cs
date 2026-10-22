using Escola.Application.DTOs.Turma;
using Escola.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Application.Services
{
    public class TurmaService : ITurmaService
    {
        public Task<TurmaGetDTO> AddAsync(TurmaPostDTO turmaPostDTO)
        {
            throw new NotImplementedException();
        }

        public Task<TurmaGetDTO> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TurmaGetDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TurmaGetDetailDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TurmaGetDTO> UpdateAsync(TurmaPutDTO turmaPutDTO)
        {
            throw new NotImplementedException();
        }
    }
}
