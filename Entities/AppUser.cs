﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UniversityServer.Extensions;

namespace UniversityServer.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; } 
        public ICollection<Course> UserCourses { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }

    }
}
 