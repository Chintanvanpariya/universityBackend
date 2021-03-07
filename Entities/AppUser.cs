using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityServer.Entities
{
    public class AppUser
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
      
        //public ICollection<Course> Courses { get; set; }
        //public ICollection<AppUserRole> UserRoles { get; set; }

    }
}
