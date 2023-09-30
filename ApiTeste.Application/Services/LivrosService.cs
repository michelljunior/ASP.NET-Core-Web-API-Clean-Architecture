using ApiTeste.Application.DTOs.Deletar;
using ApiTeste.Application.DTOs.Request;
using ApiTeste.Application.DTOs.Response;
using ApiTeste.Application.Interfaces;
using ApiTeste.Application.Utils;
using ApiTeste.Domain.Entities;
using ApiTeste.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApiTeste.Application.Services
{
    public class LivrosService : BaseService, IBaseService, ILivrosService
    {
        private readonly ILivrosRepository _livrosRepository;

        public LivrosService(SessaoUsuario sessaoUsuario, ILivrosRepository livrosRepository) : base(sessaoUsuario)
        {
            _livrosRepository = livrosRepository;
        }
        public async Task<BaseResponse> Alterar(LivroRequest model)
        {
            try
            {
                var livro = await _livrosRepository.BuscarUm(model.Titulo, model.Autor);

                if (livro != null)
                {
                    if (model.Categoria == livro.Categoria)
                        return new BaseResponse() { Status = false, Mensagem = "Nenhuma ação realizada, Altere alguma informação antes de continuar!" };

                    livro.Categoria = model.Categoria;
                    livro.DthDelete = null;
                    livro.UsuarioIdDelete = null;
                    livro.DthUpdate = DateTime.Now;
                    livro.UsuarioIdUpdate = _sessaoUsuario.GetId();

                    var ret = await _livrosRepository.Update(livro);

                    if (ret > 0)
                    {
                        return new BaseResponse() { Status = true, Mensagem = "Informações do livro alteradas com sucesso!" };
                    }
                    else
                    {
                        return new BaseResponse() { Status = false, Mensagem = "Ocorreu um erro ao alterar informações do livro!" };
                    }
                }
                else
                {
                    return new BaseResponse() { Status = true, Mensagem = "O livro selecionado não existe!" };
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Status = false, Mensagem = ex.Message };
            }
        }

        public async Task<BaseResponse> BuscarLivro(string autor, string titulo)
        {
            try
            {
                var livro = await _livrosRepository.BuscarUm(titulo, autor);

                if (livro != null)
                {
                    return new BaseResponse() { Status = true, Resultado = livro };
                }
                else
                {
                    return new BaseResponse() { Status = true, Mensagem = "O livro selecionado não existe!" };
                } 
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Status = false, Mensagem = ex.Message };
            }
        }

        public async Task<BaseResponse> Deletar(DeletarLivroRequest model)
        {
            try
            {
                var livro = await _livrosRepository.BuscarUm(model.Titulo, model.Autor);

                if (livro != null)
                {
                    if (livro.DthDelete != null)
                        return new BaseResponse() { Status = true, Mensagem = "O livro selecionado não existe!" };

                    livro.DthDelete = DateTime.Now;
                    livro.UsuarioIdDelete = _sessaoUsuario.GetId();
                    livro.DthUpdate = DateTime.Now;
                    livro.UsuarioIdDelete = _sessaoUsuario.GetId();

                    var ret = await _livrosRepository.Update(livro);

                    if (ret > 0)
                    {
                        return new BaseResponse() { Status = true, Mensagem = "Livro deletado com sucesso!" };
                    }
                    else
                    {
                        return new BaseResponse() { Status = false, Mensagem = "Ocorreu um erro ao deletar livro!" };
                    }
                }
                else
                {
                    return new BaseResponse() { Status = true, Mensagem = "O livro selecionado não existe!" };
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Status = false, Mensagem = ex.Message };
            }
        }

        public async Task<BaseResponse> Incluir(LivroRequest model)
        {
            try
            {
                var livro = await _livrosRepository.BuscarUm(model.Titulo, model.Autor);

                if (livro != null)
                {
                    if (livro.DthDelete == null)
                        return new BaseResponse() { Status = false, Mensagem = "Livro já cadastrado!" };

                    livro.Categoria = model.Categoria;
                    livro.DthDelete = null;
                    livro.UsuarioIdDelete = null;
                    livro.DthUpdate = DateTime.Now;
                    livro.UsuarioIdUpdate = _sessaoUsuario.GetId();

                    var ret = await _livrosRepository.Update(livro);

                    if (ret > 0)
                    {
                        return new BaseResponse() { Status = true, Mensagem = "Livro cadastrado com sucesso!" };
                    }
                    else
                    {
                        return new BaseResponse() { Status = false, Mensagem = "Ocorreu um erro ao cadastrar livro!" };
                    }
                }
                else
                {
                    var novoLivro = new TblLivro()
                    {
                        Titulo = model.Titulo,
                        Categoria = model.Categoria,
                        Autor = model.Autor,
                        UsuarioIdInsert = _sessaoUsuario.GetId(),
                        DthInsert = DateTime.Now,
                    };

                    var ret = await _livrosRepository.Add(novoLivro);

                    if (ret > 0)
                    {
                        return new BaseResponse() { Status = true, Mensagem = "Livro cadastrado com sucesso!" };
                    }
                    else
                    {
                        return new BaseResponse() { Status = false, Mensagem = "Ocorreu um erro ao cadastrar livro!" };
                    }
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Status = false, Mensagem = ex.Message };
            }
        }

        public async Task<BaseResponse> Listar()
        {
            try
            {
                var livros = await _livrosRepository.BuscarTodos();

                if (livros.Count == 0)
                    return new BaseResponse() { Status = false, Resultado = "Nenhum livro encontrado!" };

                return new BaseResponse() { Status = true, Resultado = livros };
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Status = false, Mensagem = ex.Message };
            }
        }
    }
}
