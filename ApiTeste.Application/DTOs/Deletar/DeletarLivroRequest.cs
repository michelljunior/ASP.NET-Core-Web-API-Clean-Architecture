using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTeste.Application.DTOs.Deletar
{
    public class DeletarLivroRequest
    {
        [Key]
        [StringLength(50, ErrorMessage = "O tamanho maximo é de 50 caracteres")]
        [Required(ErrorMessage = "O título é obrigatório")]
        public required string Titulo { get; set; }

        [Key]
        [StringLength(100, ErrorMessage = "O tamanho maximo é de 100 caracteres")]
        [Required(ErrorMessage = "O autor é obrigatório")]
        public required string Autor { get; set; }
    }
}
