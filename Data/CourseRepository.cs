using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Serendipity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityServer.Entities;
using UniversityServer.Interfaces;

namespace UniversityServer.Data
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public CourseRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<string> EnrollCourseAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> CreateCourseAsync(Course course)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Course>> GetCoursesAsync()
        {
            return await context.Courses
                .ProjectTo<Course>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<Course> GetCourseByIdAsync(int courseId)
        {
            return await context.Courses.FindAsync(courseId);
        }

        public void UpdateCourse(Course course)
        {
            context.Entry(course).State = EntityState.Modified;
        }

        public void DeleteCourseAsync(Course course)
        {
            context.Courses.Remove(course);
        }
    }
}
