using ApiTeste.Domain.Entities;

namespace ApiTeste.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<TblUsuario> BuscarUmPorUsuarioESenha(string usuario, string senha);
    }
}
