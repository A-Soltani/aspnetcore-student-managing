using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace StudentManaging.API.Infrastructure.Filters
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly IHostingEnvironment env;
        private readonly ILogger<HttpGlobalExceptionFilter> logger;

        public HttpGlobalExceptionFilter(IHostingEnvironment env, ILogger<HttpGlobalExceptionFilter> logger)
        {
            this.env = env;
            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            logger.LogError(new EventId(context.Exception.HResult),
                context.Exception,
                context.Exception.Message);

            var problemDetails = new ValidationProblemDetails()
            {
                Title = context.Exception.Message,
                Instance = context.HttpContext.Request.Path,
                Status = StatusCodes.Status400BadRequest,
                Detail = "لطفا به ویژگی خطاها برای توضیحات بیشتر مراجعه نمایید."
            };
            context.Result = new BadRequestObjectResult(problemDetails);

            if (context.Exception.InnerException != null && context.Exception.InnerException.GetType() == typeof(ValidationException))
            {
                //var errors = ((ValidationException)context.Exception.InnerException).Errors;
                //problemDetails.Errors.Add(context.Exception.Message, errors.Select(y => y.ErrorMessage).ToArray());

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                problemDetails.Errors.Add(context.Exception.Message, new string[] { });

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            context.ExceptionHandled = true;
        }



    }
}