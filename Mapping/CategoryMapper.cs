using api_rest.Domain.Models;
using api_rest.Resource;

namespace api_rest.Mapping;
    public static class CategoryMapping
    {
        public static CategoryResource ToResource(this Category category)
        {
            return new CategoryResource{Id = category.Id, Name = category.Name };
            
        }

        public static Category ToModel(this CategoryResource categoryResource)
        {
            return new Category{Id = categoryResource.Id, Name = categoryResource.Name };
        }

        public static Category ToModel(this SaveCategoryResource resource)
    {
        return new Category
        {
            Name = resource.Name 
        };
    }
    }