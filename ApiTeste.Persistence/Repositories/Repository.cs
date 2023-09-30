using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiTeste.Domain.Interfaces;
using ApiTeste.Persistence.Entities;

namespace ApiTeste.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BancoApiTesteContext _context;
        public Repository(BancoApiTesteContext context)
        {
            _context = context;
        }
        public async Task<int> Add(T entity)
        {
            try
            {
                _context.Add(entity);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw new Exception(ex.InnerException?.Message);
                else
                    throw new Exception(ex.Message);
            }

        }
        public async Task<int> Update(T entity)
        {
            try
            {
                _context.Update(entity);
                return await _context.SaveChangesAsync();
            }
            catch (SqlException ex)
            {
                throw new Exception(message: ex.InnerException?.Message);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw new Exception(ex.InnerException?.Message);
                else
                    throw new Exception(ex.Message);
            }
        }
        public async Task<bool> Delete(T entity)
        {
            try
            {
                _context.Remove(entity);
                return (await _context.SaveChangesAsync()) != 0;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw new Exception(ex.InnerException?.Message);
                else
                    throw new Exception(ex.Message);
            }
        }
    }
}
