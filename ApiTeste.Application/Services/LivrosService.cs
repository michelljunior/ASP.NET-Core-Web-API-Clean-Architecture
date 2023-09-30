using ApiTeste.Application.DTOs.Request;
using ApiTeste.Application.DTOs.Response;
using ApiTeste.Application.Interfaces;
using ApiTeste.Application.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTeste.Application.Services
{
    public class LivrosService : BaseService, IBaseService, ILivrosService
    {


        public LivrosService(SessaoUsuario sessaoUsuario) : base(sessaoUsuario)
        {
            
        }
        public async Task<BaseResponse> Alterar(LivroRequest model)
        {
            try
            {
                return new BaseResponse() { Status = true };
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Status = false, Mensagem = ex.Message };
            }
        }

        public async Task<BaseResponse> BuscarLivro(LivroRequest model)
        {
            try
            {
                return new BaseResponse() { Status = true };
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Status = false, Mensagem = ex.Message };
            }
        }

        public async Task<BaseResponse> Deletar(LivroRequest model)
        {
            try
            {
                return new BaseResponse() { Status = true };
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Status = false, Mensagem = ex.Message };
            }
        }

        public async Task<BaseResponse> Incluir(LivroRequest model)
        {
            try
            {
                return new BaseResponse() { Status = true };
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Status = false, Mensagem = ex.Message };
            }
        }

        public async Task<BaseResponse> Listar()
        {
            try
            {
                return new BaseResponse() { Status = true };
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Status = false, Mensagem = ex.Message };
            }
        }
    }
}
