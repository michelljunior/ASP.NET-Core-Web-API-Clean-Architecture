using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTeste.Application.DTOs.Response
{
    public class BaseResponse
    {
        public required bool Status { get; set; }
        public string? Mensagem { get; set; }
        public object? Resultado { get; set; }
        public List<string>? Erros { get; set; }
    }
}
