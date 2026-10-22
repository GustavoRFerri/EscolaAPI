using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Escola.Application.DTOs.Turma
{
    public class TurmaPostDTO
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [MaxLength(50, ErrorMessage = "O nome não pode exceder 50 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        [MaxLength(150, ErrorMessage = "A descrição não pode exceder 150 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo curso é obrigatório")]
        public int CursoId { get; set; }
        
    }
}
