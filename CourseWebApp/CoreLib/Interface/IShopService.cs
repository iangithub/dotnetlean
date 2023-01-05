using CoreLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.Interface
{
    public interface IShopService
    {
        public Task<bool> BookingCourseAsync(Guid userId, Guid courseScheduleId);
        public Task<List<StuCourseScheduleViewModel>> BookingListAsync(Guid userId);

        public Task<bool> BookingDeleteAsync(Guid stuScheduleId);
    }
}
