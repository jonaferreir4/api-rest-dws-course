using api_rest.Domain.Services;
using api_rest.Extensions;
using api_rest.Mapping;
using api_rest.Resource;
using Microsoft.AspNetCore.Mvc;

namespace api_rest.Controllers;

    [Route("/api/[controller]")]    
    public class ProductController(IProductService productService): Controller
    {
        private readonly IProductService _productService = productService;


        [HttpGet]
        public async Task<IActionResult> ListAsync()
        {
            var products = await _productService.ListAsync();
            var resources = products.Select(p => p.ToResource());
            return Ok(resources);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
             var result = await _productService.FindByIdAsync(id);
    
                if (!result.Success)
                    return BadRequest(result.Message);
    
                if (result.Product == null)
                    return BadRequest("product data is null.");
    
                var productResource = result.Product.ToResource();
                return Ok(productResource);
        }
        

        [HttpPost]
        public async Task<IActionResult> SaveAsync([FromBody] ProductResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var product = resource.ToModel();
            var result = await _productService.SaveAsync(product);

            if (!result.Success)
                return BadRequest(result.Message);

            if (result.Product == null)
                return BadRequest("Product data is null.");

            var productResource = result.Product.ToResource();
            return Ok(productResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ProductResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var product = resource.ToModel();
            var result = await _productService.UpdateAsync(id, product);

            if (!result.Success)
                return BadRequest(result.Message);

            if (result.Product == null)
                return BadRequest("Product data is null.");

            var productResource = result.Product.ToResource();
            return Ok(productResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _productService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Product);
        }
    }
