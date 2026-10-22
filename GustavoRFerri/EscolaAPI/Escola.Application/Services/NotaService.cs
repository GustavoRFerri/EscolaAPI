using Escola.Application.DTOs.Nota;
using Escola.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Application.Services;

public class NotaService : INotaService
{
    public Task<NotaGetDTO> AddAsync(NotaPostDTO notaPostDTO)
    {
        throw new NotImplementedException();
    }

    public Task<NotaGetDTO> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<NotaGetDTO>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<NotaGetDTO> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<NotaGetDTO> UpdateAsync(NotaPutDTO notaPutDTO)
    {
        throw new NotImplementedException();
    }
}
