using CoreLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.Interface
{
    public interface ICourseScheduleService
    {
        public Task<List<CourseScheduleViewModel>> QueryAsync(CourseScheduleQueryCondition courseScheduleQueryCondition);
    }
}
