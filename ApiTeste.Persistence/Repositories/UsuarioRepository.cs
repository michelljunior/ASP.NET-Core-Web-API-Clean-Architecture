using ApiTeste.Domain.Entities;
using ApiTeste.Domain.Interfaces;
using ApiTeste.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace ApiTeste.Persistence.Repositories
{
    public class UsuarioRepository : Repository<TblUsuario>, IUsuarioRepository
    {
        private readonly BancoApiTesteContext _context;
        public UsuarioRepository(BancoApiTesteContext context) : base(context)
        {
            _context = context;
        }

        public async Task<TblUsuario> BuscarUmPorUsuarioESenha(string usuario, string senha)
        {
            try
            {
                return await _context.TblUsuarios.Include(u => u.CpfNavigation).Where(u => u.Cpf == usuario && u.Senha == senha).FirstOrDefaultAsync();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
