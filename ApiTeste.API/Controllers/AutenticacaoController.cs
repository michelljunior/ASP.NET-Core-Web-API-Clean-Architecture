using ApiTeste.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ApiTeste.Application.DTOs.Response;
using ApiTeste.Application.DTOs.Request;
using ApiTeste.Application.Utils;
using static ApiTeste.Application.Utils.ValidaModelUtils;

namespace ApiTeste.API.Controllers
{
    public class AutenticacaoController : Controller
    {
        private readonly IAutenticacaoService _autenticacaoService;
        public AutenticacaoController(IAutenticacaoService autenticacaoService)
        {
            _autenticacaoService = autenticacaoService;
        }

        [HttpPost("Login"), ValidateModel]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            try
            {
                return Ok(await _autenticacaoService.Login(model));
            }
            catch (Exception ex)
            {
                return Ok(new BaseResponse { Status = false, Mensagem = "Falha na autenticação do sistema.", Resultado = ex.Message });
            }
        }
    }
}
