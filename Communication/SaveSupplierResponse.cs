
using api_rest.Domain.Models;

namespace api_rest.Communication;

    public class SaveSupplierResponse(bool success, string message, Supplier? supplier) : BaseResponse(success, message)
    {
        public Supplier? Supplier { get; private set; } = supplier;


        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="supplier">Saved supplier.</param>
        /// <returns>Response.</returns>
        public SaveSupplierResponse(Supplier supplier): this(true, string.Empty, supplier)
        {}

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveSupplierResponse(string message): this(false, message, null)
        {}
    }