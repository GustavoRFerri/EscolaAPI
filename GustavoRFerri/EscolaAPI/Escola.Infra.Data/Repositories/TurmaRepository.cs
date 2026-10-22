using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Infra.Data.Repositories;

public class TurmaRepository : ITurmaRepsitory
{
    public Task<Turma> AddAsync(Turma nota)
    {
        throw new NotImplementedException();
    }

    public Task<Turma> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Turma>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Turma> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Turma> UpdateAsync(Turma nota)
    {
        throw new NotImplementedException();
    }
}
