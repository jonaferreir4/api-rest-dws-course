using api_rest.Domain.Helpers;

namespace api_rest.Resource;
    public class ProductResource
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public short QuantityInPackage { get; set; }
        public EUnitOfMeasurement UnitOfMeasurement { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
    }
