using UniversityServer.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityServer.Entities;

namespace UniversityServer.Interfaces
{
    public interface ICourseRepository
    {
        void CreateCourseAsync(Course course);
        Task<CourseDto> GetCourseByIdAsync(int courseId);
        Task<IEnumerable<CourseDto>> GetCoursesAsync();
        void UpdateCourse(Course course);
        void DeleteCourseAsync(Course course);
        Task<bool> SaveAllAsync();

    }
}

