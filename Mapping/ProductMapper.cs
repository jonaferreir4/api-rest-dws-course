    using api_rest.Domain.Models;
    using api_rest.Resource;

    namespace api_rest.Mapping;
    public static class ProductMapping
    {
        public static ProductResource ToResource(this Product product)
        {
            return new ProductResource
            {
                Id = product.Id,
                Name = product.Name,
                QuantityInPackage = product.QuantityInPackage,
                UnitOfMeasurement = product.UnitOfMeasurement,
                CategoryId = product.CategoryId,
                SupplierId = product.SupplierId,
            };
        }

        public static Product ToModel(this ProductResource resource)
        {
            return new Product
            {
                Id = resource.Id,
                Name = resource.Name,
                QuantityInPackage = resource.QuantityInPackage,
                UnitOfMeasurement = resource.UnitOfMeasurement,
                CategoryId = resource.CategoryId,
                SupplierId = resource.SupplierId,
                
            };
        }
    }