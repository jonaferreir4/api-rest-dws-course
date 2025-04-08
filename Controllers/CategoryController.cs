using api_rest.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_rest.Controllers;

    [Route("/api/[controller]")]
    public class CategoryController : Controller
    {
       private readonly ICatogoryService _catogoryService;

       public CategoryController(ICatogoryService categoryService)
       {
            this._catogoryService = categoryService;

       }

       public async Task<IActionResult> GetAllAsync()
       {
            var categories = await _catogoryService.GetAllAsync();
            return Ok(categories);
       }
    }
