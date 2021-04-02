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

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserController(IUnitOfWork uow, IMapper mapr)
        {
            unitOfWork = uow;
            mapper = mapr;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var users = await unitOfWork.UserRepository.GetMembersAsync();
            return Ok(users);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<MemberDto>> GetUserByName(string name)
        {
            return await unitOfWork.UserRepository.GetMemberAsync(name);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MemberDto>> GetUser(int id)
        {
            var user = await unitOfWork.UserRepository.GetUserByIdAsync(id);
            return mapper.Map<MemberDto>(user);
        }

    } 

}