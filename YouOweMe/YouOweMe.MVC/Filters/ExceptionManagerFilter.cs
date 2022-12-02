using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using YouOweMe.Extensions;

namespace YouOweMe.MVC.Filters
{
    public class ExceptionManagerFilter : IExceptionFilter
    {
        private readonly IModelMetadataProvider modelMetadataProvider;

        private readonly ILogger logger;

        public ExceptionManagerFilter(IModelMetadataProvider modelMetadataProvider, ILoggerFactory loggerFactory)
        {
            this.modelMetadataProvider = modelMetadataProvider;
            this.logger = loggerFactory.CreateLogger("MVCExceptions");
        }

        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException)
            {
                var result = new ViewResult { ViewName = "Error" };
                result.ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary(this.modelMetadataProvider, context.ModelState);
                result.ViewData.Add("Exception", context.Exception);

                context.ExceptionHandled = true;
                context.Result = result;
            } else
            {
                var result = new ViewResult { ViewName = "Error" };
                result.ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary(this.modelMetadataProvider, context.ModelState);
                result.ViewData.Add("Exception", "Ocurrio un error inesperado... Reintente nuevamente");

                context.ExceptionHandled = true;
                context.Result = result;

                this.logger.LogError(context.Exception, context.Exception.Message);
            }
        }
    }
}
