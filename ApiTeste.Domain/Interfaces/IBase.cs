using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTeste.Domain.Interfaces
{
    internal interface IBase<T> : IRepository<T> where T : class
    {
    }
}
