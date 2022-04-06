using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayer.Core.DTOs;

namespace NLayer.API.Filters
{
    public class ValidateFilterAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(e => e.Errors).Select(e=>e.ErrorMessage).ToList();

                context.Result = new BadRequestObjectResult(CustomResponseDto<object>.Fail(400,errors));
            }
        }
    }
}
