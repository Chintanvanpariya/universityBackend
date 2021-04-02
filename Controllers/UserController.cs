using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serendipity.DTOs;
using UniversityServer.Entities;
using UniversityServer.Interfaces;

namespace UniversityServer.Controllers
{
    [Authorize]
    public class UserController : BaseApiController
    {
        private readonly IUserRepository userRepo;
        private readonly IMapper mapper;

        public UserController(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var users = await userRepo.GetMembersAsync();
            return Ok(users);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<MemberDto>> GetUserByName(string name)
        {
            return await userRepo.GetMemberAsync(name);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MemberDto>> GetUser(int id)
        {
            var user = await userRepo.GetUserByIdAsync(id);
            return mapper.Map<MemberDto>(user);
        }

    }

}