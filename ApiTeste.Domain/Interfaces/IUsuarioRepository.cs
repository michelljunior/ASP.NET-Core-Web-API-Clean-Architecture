using ApiTeste.Domain.Entities;

namespace ApiTeste.Domain.Interfaces
{
    public interface IUsuarioRepository : IBase<TblUsuario>
    {
        Task<TblUsuario> BuscarUmPorUsuarioESenha(string usuario, string senha);
    }
}
