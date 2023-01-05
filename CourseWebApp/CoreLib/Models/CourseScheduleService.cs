using CoreLib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreLib.Models
{
    public class CourseScheduleService : ICourseScheduleService
    {
        private ICourseScheduleRepository _courseScheduleRepository;

        public CourseScheduleService(ICourseScheduleRepository courseScheduleRepository)
        {
            _courseScheduleRepository = courseScheduleRepository;
        }
        public async Task<List<CourseScheduleViewModel>> QueryAsync(CourseScheduleQueryCondition courseScheduleQueryCondition)
        {
            var courseScheduleList = await _courseScheduleRepository.QueryAsync(courseScheduleQueryCondition);
            return courseScheduleList.ToList();
        }
    }
}
