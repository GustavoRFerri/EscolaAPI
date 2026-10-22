using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Application.DTOs.Nota;

public class NotaGetDTO
{
    public int Id { get; set; }
    public int MatriculaId { get; set; }
    public int ValorNota { get; set; }
    public bool Aprovado => ValorNota >= 7;    
    public DateTime DataNota { get; set; }    
}
