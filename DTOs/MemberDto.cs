using System;
using System.Collections.Generic;
using UniversityServer.Entities;

namespace Serendipity.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public ICollection<CourseDto> Courses { get; set; }
    }
}