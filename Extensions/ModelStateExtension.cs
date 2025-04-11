
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace api_rest.Extensions;
    public static class ModelStateExtension
    {
        public static List<string> GetErrorMessages( this ModelStateDictionary dictionary)
        {
           return dictionary
               .Where(m => m.Value?.Errors != null)
               .SelectMany(m => m.Value?.Errors ?? Enumerable.Empty<ModelError>())
               .Where(e => !string.IsNullOrEmpty(e.ErrorMessage))
               .Select(e => e.ErrorMessage)
               .ToList();
        }

    }
