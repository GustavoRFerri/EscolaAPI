using Escola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Domain.Interfaces;

public interface ITurmaRepsitory
{
    Task<Turma> GetByIdAsync(int id);
    //Task<IEnumerable<Curso>> GetAllAsync();
    Task<List<Turma>> GetAllAsync();
    Task<Turma> AddAsync(Turma nota);
    Task<Turma> UpdateAsync(Turma nota);
    Task<Turma> DeleteAsync(int id);
}
