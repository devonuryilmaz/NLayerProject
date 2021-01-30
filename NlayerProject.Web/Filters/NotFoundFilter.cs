using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NlayerProject.Web.ApiService;
using NLayerProject.Web.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.Web.Filters
{
    public class NotFoundFilter : ActionFilterAttribute
    {
        private readonly CategoryApiService _categoryService;
        public NotFoundFilter(CategoryApiService productService)
        {
            _categoryService = productService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();

            var product = await _categoryService.GetByIdAsync(id);

            if (product != null)
                await next();
            else
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Status = 404;
                errorDto.Errors.Add($"Id'si {id} olan kategori veritabanında bulunamadı.");

                context.Result = new RedirectToActionResult("Error", "Home", errorDto);
            }
        }
    }
}
