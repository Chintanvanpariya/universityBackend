using System.Threading.Tasks;

namespace UniversityServer.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository {get; }
        ICourseRepository CourseRepository {get; }
        //IScheduleRepository ScheduleRepository {get; }

        Task<bool> Complete();
        bool HasChanges();
    }
}