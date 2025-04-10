using api_rest.Domain.Services;
using api_rest.Extensions;
using api_rest.Mapping;
using api_rest.Resource;
using Microsoft.AspNetCore.Mvc;

namespace api_rest.Controllers;

    [Route("/api/[controller]")]
    public class CategoryController(ICategoryService categoryService) : Controller
    {
       private readonly ICategoryService _categoryService = categoryService;

    [HttpGet]
       [Route("GetAll")]
       public async Task<IActionResult> GetAllAsync()
       {
            var categories = await _categoryService.GetAllAsync();
            var resources = categories.Select(c => c.ToResource());
            return Ok(resources);
       }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCategoryResource resource)
       {
               if (!ModelState.IsValid){
                       return BadRequest(ModelState.GetErrorMessages());
               }

               var category = resource.ToModel();
               var result = await _categoryService.SaveAsync(category);

               if(!result.Success)
                  return BadRequest(result.Message);

               var categoryResource = result.Category.ToResource();
                return Ok(categoryResource);

       }
    }
