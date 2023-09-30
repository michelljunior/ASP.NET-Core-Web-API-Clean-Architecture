using ApiTeste.Application.DTOs.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTeste.Application.Utils
{
    public class ValidaModelUtils
    {
        public class ValidateModelAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                if (!context.ModelState.IsValid)
                {
                    var apiResponse = new BaseResponse()
                    {
                        Status = false,
                        Mensagem = "Erro ao identificar dados recebidos!",
                        Erros = new List<string>()
                    };

                    foreach (var modelState in context.ModelState)
                    {
                        foreach (var item in modelState.Value.Errors.Select(a => a.ErrorMessage).ToList())
                        {
                            apiResponse.Erros.Add(item);
                        }

                    }

                    context.Result = new BadRequestObjectResult(apiResponse);
                }

            }
        }
    }
}
