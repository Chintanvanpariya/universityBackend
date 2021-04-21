using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityServer.DTOs;
using UniversityServer.Entities;
using UniversityServer.Interfaces;

namespace UniversityServer.Controllers
{
    [Authorize]
    public class CourseController : BaseApiController
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CourseController(IUnitOfWork uow, IMapper mapr)
        {
            unitOfWork = uow;
            mapper = mapr;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetCourses()
        {
            var courses = await unitOfWork.CourseRepository.GetCoursesAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> GetCourse(int id)
        {
            var course = await unitOfWork.CourseRepository.GetCourseByIdAsync(id);
            return Ok(course);
        }



    }

}
