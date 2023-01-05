using CoreLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.Interface
{
    public interface ICourseScheduleRepository
    {
        Task<IEnumerable<CourseScheduleViewModel>> QueryAsync(CourseScheduleQueryCondition courseScheduleQueryCondition);
    }
}
