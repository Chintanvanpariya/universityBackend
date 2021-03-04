using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityServer.Entities
{
    public class AppUser
    {
        public DateTime DateOfBirth { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }

    }
}
