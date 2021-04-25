using System.Collections.Generic;
using UniversityServer.Entities;

namespace UniversityServer.DTOs
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public ICollection<ScheduleDto> CourseSchedule { get; set; }
        public int UserId { get; set; }
    }
}