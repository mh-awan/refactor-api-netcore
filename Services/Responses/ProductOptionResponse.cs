using RefactorThis.Models;

namespace RefactorThis.Services.Responses
{
    public class ProductOptionResponse : BaseResponse
    {
        public ProductOption ProductOption { get; private set; }

        private ProductOptionResponse(bool success, string message, ProductOption productOption) : base(success, message)
        {
            ProductOption = productOption;
        }

        public ProductOptionResponse(ProductOption productOption) : this(true, string.Empty, productOption)
        { }

        public ProductOptionResponse(string message) : this(false, message, null)
        { }
    }
}
