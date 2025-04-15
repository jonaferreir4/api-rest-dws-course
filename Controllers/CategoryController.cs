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
       public async Task<IActionResult> ListAsync()
       {
            var categories = await _categoryService.ListAsync();
            var resources = categories.Select(c => c.ToResource());
            return Ok(resources);
       }

        [HttpPost]
        public async Task<IActionResult> SaveAsync([FromBody] SaveCategoryResource resource)
       {
               if (!ModelState.IsValid){
                       return BadRequest(ModelState.GetErrorMessages());
               }

               var category = resource.ToModel();
               var result = await _categoryService.SaveAsync(category);

               if(!result.Success)
                  return BadRequest(result.Message);

               if (result.Category == null)
                   return BadRequest("Category data is null.");

               var categoryResource = result.Category.ToResource();
               return Ok(categoryResource);

       }


       [HttpPut("{id}")]
       public async Task<IActionResult> UpdateAsync(int id, [FromBody] SaveCategoryResource resource)
       {
               if (!ModelState.IsValid)
                   return BadRequest(ModelState.GetErrorMessages());

               var category = resource.ToModel();
               var result = await _categoryService.UpdateAsync(id, category);

               if (!result.Success)
                   return BadRequest(result.Message);

               if (result.Category == null)
                   return BadRequest("Category data is null.");

               var categoryResource = result.Category.ToResource();
               return Ok(categoryResource);
       }

       [HttpDelete("{id}")]
         public async Task<IActionResult> DeleteAsync(int id)
         {
                  var result = await _categoryService.DeleteAsync(id);
   
                  if (!result.Success)
                     return BadRequest(result.Message);
   
                  return Ok(result.Category);
         }
         
         [HttpGet("{id}")]
            public async Task<IActionResult> GetByIdAsync(int id)
            {
                var result = await _categoryService.GetByIdAsync(id);
    
                if (!result.Success)
                    return BadRequest(result.Message);
    
                if (result.Category == null)
                    return BadRequest("Category data is null.");
    
                var categoryResource = result.Category.ToResource();
                return Ok(categoryResource);
            }
    }
