using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SolucaoErpDomain.Configuration.ErrorsApi;

namespace SolucaoErpDomain.Configurations.Errors
{
    public class ActionHandlersAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errorResponse = new ResponseData() { Successful = false, Message = "Erro de validação de campos", codError = 2 };
                var errorsInModelState = context.ModelState.Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage).ToArray());

                foreach (var error in errorsInModelState)
                {
                    foreach (var subError in error.Value)
                    {
                        var errorModel = new ErrorModel
                        {
                            Message = subError
                        };
                        errorResponse.Error.Add(errorModel);
                    }
                }
                context.Result = new BadRequestObjectResult(errorResponse);
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is NotFoundException)
            {
                var apiException = (ApiException)context.Exception;
                var errorResponse = new ResponseData() { Successful = false, Message = "Erro generalizado da API", codError = 1 };
                var errorModel = new ErrorModel() { Message = apiException.Message };
                errorResponse.Error.Add(errorModel);
                context.Result = new NotFoundObjectResult(errorResponse);
                context.ExceptionHandled = true;
                return;
            }
            if (context.Exception is ApiException)
            {
                var apiException = (ApiException)context.Exception;
                var errorResponse = new ResponseData() { Successful = false, Message = "Erro generalizado da API", codError = 1 };
                var errorModel = new ErrorModel() { Message = apiException.Message };
                errorResponse.Error.Add(errorModel);
                context.Result = new BadRequestObjectResult(errorResponse);
                context.ExceptionHandled = true;
            }
        }
    }
}
