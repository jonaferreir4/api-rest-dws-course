

using System.ComponentModel.DataAnnotations;

namespace api_rest.Resource;
    public class SaveCategoryResource
    {
        [Required]
        [MaxLength(30)]
        public required string Name { get; set; }   
    }
