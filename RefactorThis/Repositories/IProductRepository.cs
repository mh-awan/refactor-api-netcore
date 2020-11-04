using System.Collections.Generic;
using System.Threading.Tasks;
using RefactorThis.Models;

namespace RefactorThis.Repositories
{
    public interface IProductRepository
    {
         Task<IEnumerable<Product>> GetProductsAsync();
    }
}
