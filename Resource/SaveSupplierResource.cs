

using System.ComponentModel.DataAnnotations;

namespace api_rest.Resource;
    public class SaveSupplierResource
    {
        [Required]
        [MaxLength(30)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Address { get; set; }

        [Required]
        [MaxLength(30)]
        public required string PhoneNumber { get; set; }

        [Required]
        [MaxLength(30)]
        public required string ContactEmail { get; set; }
    }