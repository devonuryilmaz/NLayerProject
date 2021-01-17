using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NLayerProject.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.Filters
{
    public class ValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                ErrorDto errorDto = new ErrorDto();

                errorDto.Status = 400;

                IEnumerable<ModelError> errors = context.ModelState.Values.SelectMany(v => v.Errors);

                errors.ToList().ForEach(e =>
                    errorDto.Errors.Add(e.ErrorMessage));

                context.Result = new BadRequestObjectResult(errorDto);
            }
        }
    }
}
