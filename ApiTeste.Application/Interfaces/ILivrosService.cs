using ApiTeste.Application.DTOs.Deletar;
using ApiTeste.Application.DTOs.Request;
using ApiTeste.Application.DTOs.Response;

namespace ApiTeste.Application.Interfaces
{
    public interface ILivrosService
    {
        Task<BaseResponse> Listar();
        Task<BaseResponse> BuscarLivro(string autor, string titulo);
        Task<BaseResponse> Incluir(LivroRequest model);
        Task<BaseResponse> Alterar(LivroRequest model);
        Task<BaseResponse> Deletar(DeletarLivroRequest model);

    }
}
