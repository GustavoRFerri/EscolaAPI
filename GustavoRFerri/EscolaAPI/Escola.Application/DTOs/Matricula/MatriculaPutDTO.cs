using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Escola.Application.DTOs.Matricula
{
    public class MatriculaPutDTO
    {        
        [Required(ErrorMessage = "A matricula é obrigatória")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O usuario é obrigatório")]
        public int TurmaId { get; set; }

        [Required(ErrorMessage = "A data de expiração é obrigatória")]
        public DateTime DataExpiracao { get; set; }
        
    }
}
