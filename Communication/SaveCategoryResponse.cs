
using api_rest.Domain.Models;

namespace api_rest.Communication;

    public class SaveCategoryResponse(bool success, string message, Category category) : BaseResponse(success, message)
    {
        public Category Category { get; private set; } = category;


        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="category">Saved category.</param>
        /// <returns>Response.</returns>
        public SaveCategoryResponse(Category category): this(true, string.Empty, category)
        {}

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveCategoryResponse(string message): this(false, message, null)
        {}
    }