using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using LibraryManagement.Models;

namespace LibraryManagement.Middleware
{
    public class LibraryExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public LibraryExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "text/html";

                var errorModel = new ErrorViewModel
                {
                    RequestId = Guid.NewGuid().ToString(),
                    Message = ex.Message
                };

                var actionContext = new ActionContext(
                    context,
                    context.GetRouteData(),
                    new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor());

                var viewResult = new ViewResult
                {
                    ViewName = "~/Views/Shared/Error.cshtml",
                    ViewData = new ViewDataDictionary<ErrorViewModel>(
                        new EmptyModelMetadataProvider(),
                        new ModelStateDictionary())
                    { Model = errorModel }
                };

                await viewResult.ExecuteResultAsync(actionContext);
            }
        }
    }
}