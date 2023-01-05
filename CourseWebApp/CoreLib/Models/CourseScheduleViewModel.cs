﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLib.Models
{
    public class CourseScheduleViewModel
    {
        public Guid Id { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string TeacherName { get; set; }
        public string CourseDesc { get; set; }
        public int CourseTimes { get; set; }
        public DateTime Sdate { get; set; }
        public DateTime Edate { get; set; }
        public string Location { get; set; }
    }
}
