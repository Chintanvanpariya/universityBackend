using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityServer.DTOs;
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

        //public async Task<string> EnrollCourseAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public void CreateCourseAsync(Course course)
        {
            context.Courses.Add(course);
        }

        public async Task<IEnumerable<CourseDto>> GetCoursesAsync()
        {
            return await context.Courses
                .ProjectTo<CourseDto>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<CourseDto> GetCourseByIdAsync(int courseId)
        {
            return await context.Courses
               .Where(x => x.Id == courseId)
               .ProjectTo<CourseDto>(mapper.ConfigurationProvider)
               .SingleOrDefaultAsync();
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
