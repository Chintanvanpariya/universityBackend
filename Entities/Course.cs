using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityServer.Entities
{
    [Table("Courses")]
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public ICollection<Schedule> CourseSchedule { get; set; }
    }
}
