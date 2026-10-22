using Escola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Domain.Interfaces;

public interface IMatriculaRepository
{
    Task<Matricula> GetByIdAsync(int id);
    //Task<IEnumerable<Curso>> GetAllAsync();
    Task<List<Matricula>> GetAllAsync();
    Task<Matricula> AddAsync(Matricula curso);
    Task<Matricula> UpdateAsync(Matricula curso);
    Task<Matricula> DeleteAsync(int id);
}
