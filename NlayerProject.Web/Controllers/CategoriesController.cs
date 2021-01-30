using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NlayerProject.Web.ApiService;
using NLayerProject.Web.Dto;
using NLayerProject.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NlayerProject.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoryApiService _service;

        public CategoriesController(CategoryApiService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _service.GetAllAsync();

            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            var category = await _service.AddAsync(categoryDto);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var category = await _service.GetByIdAsync(id);

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            await _service.Update(categoryDto);

            return RedirectToAction("Index");
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Remove(id);

            return RedirectToAction("Index");
        }
    }
}
