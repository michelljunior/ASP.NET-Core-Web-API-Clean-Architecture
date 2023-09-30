using ApiTeste.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ApiTeste.Application.DTOs.Response;
using ApiTeste.Application.DTOs.Request;
using ApiTeste.Application.Utils;
using static ApiTeste.Application.Utils.ValidaModelUtils;
using ApiTeste.Application.DTOs.Enums;

namespace ApiTeste.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : Controller
    {
        private readonly ILivrosService _LivrosService;
        public LivrosController(ILivrosService LivrosService)
        {
            _LivrosService = LivrosService;
        }

        [HttpPost]
        [Authorize(Roles = RolesAuthorize.UsuarioRole)]
        public async Task<IActionResult> Adicionar([FromBody] LivroRequest model)
        {
            try
            {
                return Ok(await _LivrosService.Incluir(model));
            }
            catch (Exception ex)
            {
                return Ok(new BaseResponse { Status = false, Mensagem = "Falha ao adicionar livro.", Resultado = ex.Message });
            }
        }

        [HttpPut]
        [Authorize(Roles = RolesAuthorize.UsuarioRole)]
        public async Task<IActionResult> Alterar([FromBody] LivroRequest model)
        {
            try
            {
                return Ok(await _LivrosService.Alterar(model));
            }
            catch (Exception ex)
            {
                return Ok(new BaseResponse { Status = false, Mensagem = "Falha ao alterar livro.", Resultado = ex.Message });
            }
        }

        [HttpDelete]
        [Authorize(Roles = RolesAuthorize.UsuarioRole)]
        public async Task<IActionResult> Deletar([FromBody] LivroRequest model)
        {
            try
            {
                return Ok(await _LivrosService.Deletar(model));
            }
            catch (Exception ex)
            {
                return Ok(new BaseResponse { Status = false, Mensagem = "Falha ao deletar livro.", Resultado = ex.Message });
            }
        }

        [HttpGet]
        [Authorize(Roles = RolesAuthorize.UsuarioRole)]
        public async Task<IActionResult> Listar()
        {
            try
            {
                return Ok(await _LivrosService.Listar());
            }
            catch (Exception ex)
            {
                return Ok(new BaseResponse { Status = false, Mensagem = "Falha ao listar livros cadastrados.", Resultado = ex.Message });
            }
        }

        [HttpGet("{livro}")]
        [Authorize(Roles = RolesAuthorize.UsuarioRole)]
        public async Task<IActionResult> BuscarLivro(LivroRequest livro)
        {
            try
            {
                return Ok(await _LivrosService.BuscarLivro(livro));
            }
            catch (Exception ex)
            {
                return Ok(new BaseResponse { Status = false, Mensagem = "Falha ao listar livros cadastrados.", Resultado = ex.Message });
            }
        }
    }
}
