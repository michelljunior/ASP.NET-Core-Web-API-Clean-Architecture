using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ApiTeste.Application.Utils
{
    public class StringUtils
    {
        public static string PegarNumeros(string texto)
        {
            return Regex.Replace(texto, "\\D", "");
        }
    }
}
