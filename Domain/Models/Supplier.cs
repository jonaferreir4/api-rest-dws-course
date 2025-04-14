
namespace api_rest.Domain.Models;
    public class Supplier
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string ContactEmail { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Address { get; set; }

        public IList<Product> Products { get; set; } = [];
    }