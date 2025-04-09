using api_rest.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_rest.Controllers;

    [Route("/api/[controller]")]
    public class CategoryController : Controller
    {
       private readonly ICategoryService _categoryService;

       public CategoryController(ICategoryService categoryService)
       {
            this._categoryService = categoryService;

       }
       [HttpGet]
       [Route("GetAll")]
       public async Task<IActionResult> GetAllAsync()
       {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
       }
    }
