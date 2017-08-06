
namespace CQRS.CQRSCode
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using System.Net;

    /// <summary>
    /// Attribute to filter bad requests with FluentValidation
    /// </summary>
    public class BadRequestActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                // Log the error and add it to the body
            }

            base.OnActionExecuting(context);
        }
    }
}
