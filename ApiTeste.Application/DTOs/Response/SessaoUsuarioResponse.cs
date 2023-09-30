using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTeste.Application.DTOs.Response
{
    internal class SessaoUsuarioResponse
    {
        public int UsuarioId { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
    }
}
