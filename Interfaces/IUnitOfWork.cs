using System.Threading.Tasks;

namespace UniversityServer.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository {get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}