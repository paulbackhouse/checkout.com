using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;

namespace Checkout.Web.App.Filters
{
    /// <summary>
    /// ensures models are valid
    /// </summary>
    public class ModelStateValidationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                List<string> list = (from modelState in context.ModelState.Values
                                     from error in modelState.Errors
                                     select error.ErrorMessage).ToList();

                //Also add exceptions.
                list.AddRange(from modelState in context.ModelState.Values
                              from error in modelState.Errors
                              where error.Exception != null
                              select error.Exception.ToString());

                context.Result = new BadRequestObjectResult(list);
            }

            base.OnActionExecuting(context);
        }
    }
}
