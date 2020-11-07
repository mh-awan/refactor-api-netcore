using RefactorThis.Models;

namespace RefactorThis.Services.Responses
{
    public class SaveProductResponse : BaseResponse
    {
        public Product Product { get; private set; }

        private SaveProductResponse(bool success, string message, Product product) : base(success, message)
        {
            Product = product;
        }

        public SaveProductResponse(Product product) : this(true, string.Empty, product)
        { }

        public SaveProductResponse(string message) : this(false, message, null)
        { }
    }
}
