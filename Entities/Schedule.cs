﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityServer.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public TimeSpan Fromtime { get; set; }
        public TimeSpan ToTime { get; set; }
        public string Day { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}
