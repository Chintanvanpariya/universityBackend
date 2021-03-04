using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace UniversityServer.Entities
{
    public class AppRole : IdentityRole<int>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}