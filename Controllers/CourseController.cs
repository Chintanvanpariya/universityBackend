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

        [Authorize(Policy = "AdminLevel")]
        [HttpPost("add")]
        public async Task<ActionResult<string>> AddCourse(CourseDto courseDto)
        {
            var user = await unitOfWork.UserRepository.GetUserByIdAsync(courseDto.UserId);

            if (user != null)
            {
                var course = mapper.Map<Course>(courseDto);

                unitOfWork.CourseRepository.CreateCourseAsync(course);

                if (await unitOfWork.Complete()) return Ok("Course Created Successfully");
            }
            return BadRequest("Faculty Does not exist !");
        }

        [Authorize(Policy = "AdminLevel")]
        [HttpPost("update")]
        public async Task<ActionResult<string>> UpdateCourse(CourseDto coursedto)
        {
            if (coursedto.UserId != null)
            {
                var user = await unitOfWork.UserRepository.GetUserByIdAsync(coursedto.UserId);
                if (user == null)
                {
                    return BadRequest("Updated Faculty Does not exist !");
                }
            }

            var courseFromDb = await unitOfWork.CourseRepository.GetCourseByIdAsync(coursedto.Id);

            if (courseFromDb != null)
            {
                var course = mapper.Map<Course>(coursedto);

                unitOfWork.CourseRepository.UpdateCourse(course);

                if (await unitOfWork.Complete()) return Ok("Course Updated Successfully");
            }

            return BadRequest("Update Failed ! Course does not exist.");
        }

        [Authorize(Policy = "AdminLevel")]
        [HttpDelete("remove/{id}")]
        public async Task<ActionResult> DeleteCourse(int id)
        {
            var courseDto = await unitOfWork.CourseRepository.GetCourseByIdAsync(id);

            if (courseDto == null)
            {
                return BadRequest("Course Not Found");
            }
            var course = mapper.Map<Course>(courseDto);

            unitOfWork.CourseRepository.DeleteCourseAsync(course);

            if (await unitOfWork.Complete()) return Ok();

            return BadRequest("Problem deleting the message");
        }


    }

}
