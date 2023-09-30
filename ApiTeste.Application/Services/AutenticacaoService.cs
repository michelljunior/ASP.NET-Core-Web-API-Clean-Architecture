using ApiTeste.Application.DTOs.Request;
using ApiTeste.Application.DTOs.Response;
using ApiTeste.Application.Interfaces;
using ApiTeste.Application.Utils;
using ApiTeste.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTeste.Application.Services
{
    public class AutenticacaoService : BaseService, IBaseService, IAutenticacaoService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public AutenticacaoService(SessaoUsuario sessaoUsuario, IUsuarioRepository usuarioRepository) : base(sessaoUsuario)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<BaseResponse> Login(LoginRequest model)
        {
            try
            {
                if (String.IsNullOrEmpty(model.Usuario) || String.IsNullOrEmpty(model.Senha))
                    return new BaseResponse { Status = false, Mensagem = $"Preencha todos os campos antes de tentar autenticar!" };

                model.Usuario = StringUtils.PegarNumeros(model.Usuario);
                model.Senha = CriptografiaUtils.CriptografarSenha(model.Senha);

                var usuario = await _usuarioRepository.BuscarUmPorUsuarioESenha(model.Usuario, model.Senha);

                if (usuario == null)
                    return new BaseResponse() { Status = false, Mensagem = "O Usuario que você tentou acessar não foi encontrado!" };

                var sessaoUsuario = new SessaoUsuarioResponse()
                {
                    Cpf = usuario.Cpf,
                    Nome = usuario.CpfNavigation.Nome,
                    UsuarioId = usuario.UsuarioId
                };

                var token = CriptografiaUtils.GerarToken(sessaoUsuario);

                return new BaseResponse() { Status = true, Resultado = token };
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Status = false, Mensagem = ex.Message };
            }
        }
    }
}
