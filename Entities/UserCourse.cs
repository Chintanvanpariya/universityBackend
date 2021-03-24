using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityServer.Entities
{
    public class UserCourse
    {
        public AppUser User { get; set; }
        public int UserId { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }

    }
}
