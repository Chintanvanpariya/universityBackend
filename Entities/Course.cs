using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
 
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
