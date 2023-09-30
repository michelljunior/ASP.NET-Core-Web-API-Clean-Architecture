using ApiTeste.Application.DTOs.Request;
using ApiTeste.Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTeste.Application.Interfaces
{
    public interface IAutenticacaoService
    {
        Task<BaseResponse> Login(LoginRequest model);
    }
}
