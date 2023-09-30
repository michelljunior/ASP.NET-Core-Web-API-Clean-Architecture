using ApiTeste.Application.DTOs.Request;
using ApiTeste.Application.DTOs.Response;

namespace ApiTeste.Application.Interfaces
{
    public interface ILivrosService
    {
        Task<BaseResponse> Listar();
        Task<BaseResponse> BuscarLivro(LivroRequest model);
        Task<BaseResponse> Incluir(LivroRequest model);
        Task<BaseResponse> Alterar(LivroRequest model);
        Task<BaseResponse> Deletar(LivroRequest model);

    }
}
