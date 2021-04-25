using System.Linq;
using System.Threading.Tasks;
using UniversityServer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityServer.DTOs;
using AutoMapper;
using UniversityServer.Interfaces;


namespace UniversityServer.Controllers
{
    public class AdminController : BaseApiController
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public AdminController(UserManager<AppUser> userManager, IMapper mapper, IUnitOfWork uow)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.unitOfWork = uow;
        }


        [Authorize(Policy = "AdminLevel")]
        [HttpPost("add-faculty")]
        public async Task<ActionResult<UserDto>> AddFaculty(RegisterDto registerDto)
        {
            if (await userManager.Users.AnyAsync(x => x.Email == registerDto.Email.ToLower())) return BadRequest("Username is taken");

            var user = mapper.Map<AppUser>(registerDto);

            user.Email = user.Email.ToLower();
            user.UserName = user.Email.ToLower();

            var result = await userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            var roleResult = await userManager.AddToRoleAsync(user, "Faculty");

            if (!roleResult.Succeeded) return BadRequest(result.Errors);

            return new UserDto
            {
                Email = user.Email,
                Token = "_blank"
            };

        }

        [Authorize(Policy = "AdminLevel")]
        [HttpPost("add-course")]
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
        [HttpPost("course-update")]
        public async Task<ActionResult<string>> UpdateCourse(CourseDto coursedto)
        {
            var user = await unitOfWork.UserRepository.GetUserByIdAsync(coursedto.UserId);
            if(user == null)
            {
                return BadRequest("Updated Faculty Does not exist !");
            }
            var courseFromDb = await unitOfWork.CourseRepository.GetCourseByIdAsync(coursedto.Id);
            
            if(courseFromDb != null)
            {
                var course = mapper.Map<Course>(coursedto);

                unitOfWork.CourseRepository.UpdateCourse(course);

                if (await unitOfWork.Complete()) return Ok("Course Updated Successfully");
            }
            
            return BadRequest("Update Failed ! Course does not exist.");
        }

        [Authorize(Policy = "AdminLevel")]
        [HttpDelete("remove-course/{id}")]
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

        [Authorize(Policy = "AdminLevel")]
        [HttpGet("users-with-roles")]
        public async Task<ActionResult> GetUsersWithRoles()
        {
            var users = await userManager.Users
                .Include(r => r.UserRoles)
                .ThenInclude(r => r.Role)
                .OrderBy(u => u.UserName)
                .Select(u => new
                {
                    u.Id,
                    Username = u.UserName,
                    Roles = u.UserRoles.Select(r => r.Role.Name).ToList()
                })
                .ToListAsync();

            return Ok(users);
        }


        [Authorize(Policy = "AdminLevel")]
        [HttpPost("edit-roles/{username}")]
        public async Task<ActionResult> EditRoles(string username, [FromQuery] string roles)
        {
            var selectedRoles = roles.Split(",").ToArray();

            var user = await userManager.FindByNameAsync(username);

            if (user == null) return NotFound("Could not find user");

            var userRoles = await userManager.GetRolesAsync(user);

            var result = await userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles));

            if (!result.Succeeded) return BadRequest("Failed to add to roles");

            result = await userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles));

            if (!result.Succeeded) return BadRequest("Failed to remove from roles");

            return Ok(await userManager.GetRolesAsync(user));
        }


    }
}