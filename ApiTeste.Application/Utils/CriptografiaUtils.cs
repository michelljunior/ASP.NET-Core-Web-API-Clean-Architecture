using ApiTeste.Application.DTOs.Enums;
using ApiTeste.Application.DTOs.Response;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ApiTeste.Application.Utils
{
    internal class CriptografiaUtils
    {
        public static string CriptografarSenha(string textoParaCriptografar)
        {
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(textoParaCriptografar));

            StringBuilder builder = new();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }

        public static string GerarToken(SessaoUsuarioResponse sessao)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SegurancaUtils.Secret);
            var token = new SecurityTokenDescriptor();
            token.Expires = DateTime.UtcNow.AddHours(8);

            var sessaoClaim = new Claim[]
            {
                new Claim(ClaimTypes.Sid, sessao.UsuarioId.ToString()),
                new Claim(ClaimTypes.SerialNumber, sessao.Cpf),
                new Claim(ClaimTypes.Role, RolesAuthorize.UsuarioRole),
                new Claim("Nome", sessao.Nome),
            };

            var claims = new ClaimsIdentity(sessaoClaim);

            token.Subject = claims;

            token.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var tokenAuth = tokenHandler.CreateToken(token);
            return tokenHandler.WriteToken(tokenAuth);
        }
    }
}
