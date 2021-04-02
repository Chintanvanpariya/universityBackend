using Serendipity.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityServer.DTOs;
using UniversityServer.Entities;

namespace UniversityServer.Interfaces
{
    public interface ICourseRepository
    {
        void CreateCourseAsync(Course course);
        Task<Course> GetCourseByIdAsync(int courseId);
        Task<IEnumerable<Course>> GetCoursesAsync();
        void UpdateCourse(Course course);
        void DeleteCourseAsync(Course course);
        Task<bool> SaveAllAsync();

    }
}

