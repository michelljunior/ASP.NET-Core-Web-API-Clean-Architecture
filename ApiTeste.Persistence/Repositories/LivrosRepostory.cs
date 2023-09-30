using ApiTeste.Domain.Entities;
using ApiTeste.Persistence.Entities;
using ApiTeste.Domain.Interfaces;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ApiTeste.Persistence.Repositories
{
    public class LivrosRepostory : Repository<TblLivro>, ILivrosRepository
    {
        private readonly BancoApiTesteContext _context;
        public LivrosRepostory(BancoApiTesteContext context) : base(context)
        {
            _context = context;
        }

        public async Task<TblLivro> BuscarUm(string titulo, string autor)
        {
            try
            {
                return await _context.TblLivros.Where(l => l.Titulo == titulo && l.Autor == autor).FirstOrDefaultAsync();
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

        public async Task<List<TblLivro>> BuscarTodos()
        {
            try
            {
                return await _context.TblLivros.Where(l => l.DthDelete == null).ToListAsync();
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
