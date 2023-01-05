using CoreLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.Interface
{
    public interface IStuCourseScheduleRepository
    {
        public Task<bool> AddScheduleAsync(Guid userId, Guid courseScheduleId);
        public Task<StuCourseScheduleViewModel> GetScheduleAsync(Guid userId, Guid courseScheduleId);

        public Task<List<StuCourseScheduleViewModel>> GetScheduleAsync(Guid userId);
        public Task<bool> DeleteScheduleAsync(Guid stuScheduleId);
    }
}
