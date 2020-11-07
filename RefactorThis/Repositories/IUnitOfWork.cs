using System.Threading.Tasks;

namespace RefactorThis.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
