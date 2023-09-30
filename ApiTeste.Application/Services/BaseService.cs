using ApiTeste.Application.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTeste.Application.Services
{
    public class BaseService
    {
            public readonly SessaoUsuario _sessaoUsuario;

            public BaseService(SessaoUsuario sessaoUsuario)
            {
                _sessaoUsuario = sessaoUsuario;
            }
    }
}
