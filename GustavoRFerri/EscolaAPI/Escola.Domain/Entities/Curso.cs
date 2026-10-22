using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Domain.Entities;

public class Curso
{
    public int Id { get; set; }
    public string Nomes { get; set; }
    public string Descricaos { get; set; }
    public bool Excluidos { get; set; }
    public ICollection<Turma> Turmas { get; set; }
}
