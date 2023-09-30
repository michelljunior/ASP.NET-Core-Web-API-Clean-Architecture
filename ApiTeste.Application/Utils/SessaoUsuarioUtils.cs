using ApiTeste.Application.DTOs.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApiTeste.Application.Utils
{
    public class SessaoUsuario
    {
        private readonly IHttpContextAccessor _accessor;

        public SessaoUsuario(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string UsuarioId => GetClaimsIdentity().FirstOrDefault(a => a.Type == ClaimTypes.Sid)?.Value;
        public string Cpf => GetClaimsIdentity().FirstOrDefault(a => a.Type == ClaimTypes.SerialNumber)?.Value;
        public string Nome => GetClaimsIdentity().FirstOrDefault(a => a.Type == "Nome")?.Value;
       
        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor?.HttpContext?.User.Claims;
        }

        public HttpRequest GetUserRequest()
        {
            return _accessor?.HttpContext?.Request;
        }

        public string GetToken()
        {
            string userAuth = _accessor?.HttpContext?.Request.Headers["authorization"].ToString();
            userAuth = userAuth.Replace("Bearer ", "");

            return userAuth;
        }

        public ConnectionInfo GetUserConnection()
        {
            return _accessor?.HttpContext?.Connection;
        }

        public int GetId()
        {
            return int.Parse(UsuarioId ?? "0");
        }
    }
}
