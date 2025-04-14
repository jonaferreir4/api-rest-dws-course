
using api_rest.Domain.Models;

namespace api_rest.Communication;

    public class SaveProductResponse(bool success, string message, Product? product) : BaseResponse(success, message)
    {
        public Product? Product { get; private set; } = product;


        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="product">Saved product.</param>
        /// <returns>Response.</returns>
        public SaveProductResponse(Product product): this(true, string.Empty, product)
        {}

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveProductResponse(string message): this(false, message, null)
        {}
    }