using ApiTeste.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTeste.Domain.Interfaces
{
    public interface ILivrosRepository : IBase<TblLivro>
    {
        /// <summary>
        /// Busca um livro por titulo e autor.
        /// </summary>
        /// <param name="titulo"></param>
        /// <param name="autor"></param>
        /// <returns></returns>
        Task<TblLivro> BuscarUm(string titulo, string autor);

        /// <summary>
        /// Busca todos os livros registrados
        /// </summary>
        /// <param name="titulo"></param>
        /// <param name="categoria"></param>
        /// <param name="autor"></param>
        /// <returns></returns>
        Task<List<TblLivro>> BuscarTodos();
    }
}
