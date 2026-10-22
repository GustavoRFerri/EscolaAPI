using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Escola.Application.DTOs.Curso
{
    public class CursoPutDTO
    {

        [Required(ErrorMessage = "O identificador do curso é obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do curso é obrigatório")]
        [MaxLength(100, ErrorMessage = "O nome do curso deve ter no máximo 50 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição do curso é obrigatória")]
        [MaxLength(150, ErrorMessage = "A descrição do curso deve ter no máximo 150 caracteres")]
        public string Descricao { get; set; }
    }
}
