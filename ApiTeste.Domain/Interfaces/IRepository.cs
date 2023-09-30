using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTeste.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<int> Add(T entity);
        Task<int> Update(T entity);
        Task<bool> Delete(T entity);
    }
}
