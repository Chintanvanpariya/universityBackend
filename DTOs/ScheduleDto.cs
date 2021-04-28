using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityServer.DTOs
{
    public class ScheduleDto
    {
        public int Id { get; set; }
        public string Fromtime { get; set; }
        public string ToTime { get; set; }
        public string Day { get; set; }
        public int CourseId { get; set; }
        public int FacultyId { get; set; }
    }
}
