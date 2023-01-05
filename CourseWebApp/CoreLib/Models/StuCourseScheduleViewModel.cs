using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLib.Models
{
    public class StuCourseScheduleViewModel
    {
        public Guid Id { get; set; }
        public Guid CourseSchueduleId { get; set; }
        public string CourseName { get; set; }
        public string TeacherName { get; set; }
        public DateTime Sdate { get; set; }
        public DateTime Edate { get; set; }
    }
}
