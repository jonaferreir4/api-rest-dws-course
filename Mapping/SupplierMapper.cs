
using api_rest.Domain.Models;
using api_rest.Resource;

namespace api_rest.Mapping;
    public static class SupplierMapping
    {
        public static SupplierResource ToResource(this Supplier supplier)
        {
            return new SupplierResource
            {
                Id = supplier.Id,
                Name = supplier.Name,
                Address = supplier.Address,
                PhoneNumber = supplier.PhoneNumber,
                ContactEmail = supplier.ContactEmail
            };
        }

        public static Supplier ToModel(this SupplierResource supplierResource)
        {
            return new Supplier
            {
                Id = supplierResource.Id,
                Name = supplierResource.Name,
                Address = supplierResource.Address,
                PhoneNumber = supplierResource.PhoneNumber,
                ContactEmail = supplierResource.ContactEmail
            };
        }

        public static Supplier ToModel(this SaveSupplierResource resource)
        {
            return new Supplier
            {
                Name = resource.Name,
                Address = resource.Address,
                PhoneNumber = resource.PhoneNumber,
                ContactEmail = resource.ContactEmail
            };
        }
    }