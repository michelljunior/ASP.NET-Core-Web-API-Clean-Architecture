using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTeste.Application.DTOs.Request
{
    public class LoginRequest
    {
        public required string Usuario { get; set; }
        public required string Senha { get; set; }
    }
}
