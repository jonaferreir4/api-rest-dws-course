
using api_rest.Domain.Services;
using api_rest.Extensions;
using api_rest.Mapping;
using api_rest.Resource;
using Microsoft.AspNetCore.Mvc;

namespace api_rest.Controllers;

    [Route("/api/[controller]")]
    public class SupplierController(ISupplierService supplierService): Controller
    {
        private readonly ISupplierService _supplierService = supplierService;

        [HttpGet]
        public async Task<IActionResult> ListAsync()
        {   
            var suppliers = await _supplierService.ListAsync();
            var resources = suppliers.Select(s => s.ToResource());
            return Ok(resources);
        }
        [HttpPost]
        public async Task<IActionResult> SaveAsync([FromBody] SaveSupplierResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var supplier = resource.ToModel();
            var result = await _supplierService.SaveAsync(supplier);

            if (!result.Success)
                return BadRequest(result.Message);

            if (result.Supplier == null)
                return BadRequest("Supplier data is null.");

            var supplierResource = result.Supplier.ToResource();
            return Ok(supplierResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] SaveSupplierResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var supplier = resource.ToModel();
            var result = await _supplierService.UpdateAsync(id, supplier);

            if (!result.Success)
                return BadRequest(result.Message);

            if (result.Supplier == null)
                return BadRequest("Supplier data is null.");

            var supplierResource = result.Supplier.ToResource();
            return Ok(supplierResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _supplierService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _supplierService.GetByIdAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            if (result.Supplier == null)
                return NotFound();

            var supplierResource = result.Supplier.ToResource();
            return Ok(supplierResource);
        }
    }