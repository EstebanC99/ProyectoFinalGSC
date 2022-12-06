using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using YouOweMe.Extensions;

namespace YouOweMe.WebApi.Filter
{
    public class YouOweMeFilter : IActionFilter
    {
        private readonly ILogger Logger;

        public YouOweMeFilter(ILoggerFactory loggerFactory)
        {
            this.Logger = loggerFactory.CreateLogger("YouOweMe");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                try
                {
                    throw context.Exception;
                }
                catch (ValidationException vex)
                {
                    context.ExceptionHandled = true;

                    context.Result = new ObjectResult(vex.Message)
                    {
                        StatusCode = StatusCodes.Status500InternalServerError
                    };
                }
                catch (Exception ex)
                {
                    context.ExceptionHandled = true;

                    context.Result = new ObjectResult("Ocurrio un error inesperado")
                    {
                        StatusCode = StatusCodes.Status500InternalServerError,
                    };

                    this.Logger.LogError(ex, ex.Message);
                }
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}
