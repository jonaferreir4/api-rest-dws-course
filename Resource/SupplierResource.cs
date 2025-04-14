
namespace api_rest.Resource;
    public class SupplierResource
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;
    }