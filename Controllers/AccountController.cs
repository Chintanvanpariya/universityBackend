using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityServer.Data;
using UniversityServer.Entities;

namespace UniversityServer.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        public AccountController(DataContext context)
        {
            this._context = context;
        }

        //[HttpPost("register")]
        //public async Task<ActionResult<AppUser>> Register(string email, string password)
        //{

        //}
    }
}
