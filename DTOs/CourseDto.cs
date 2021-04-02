using System.Collections.Generic;
using UniversityServer.Entities;

namespace Serendipity.DTOs
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public ICollection<Schedule> CourseSchedule { get; set; }
    }
}