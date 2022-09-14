using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary.DataModels
{
    public class CourseInfo
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Times { get; set; }
        public string Description { get; set; }
    }


    public class CourseScheduleInfo
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string TeacherName { get; set; }
        public DateTime Sdate { get; set; }
        public DateTime Edate { get; set; }
        public int Times { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

    }

    public class CourseScheduleCreateModel
    {
        public Guid Id { get; set; }
        public Guid Cid { get; set; }
        public Guid Tid { get; set; }
        public DateTime Sdate { get; set; }
        public DateTime Edate { get; set; }
        public string Location { get; set; }

        public CourseScheduleCreateModel()
        {
            this.Id = Guid.NewGuid();
            this.Sdate = DateTime.Now;
            this.Edate = DateTime.Now;
        }
    }
}
