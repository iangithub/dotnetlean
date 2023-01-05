using CoreLib.Interface;
using CoreLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.Service
{
    public class ShopService : IShopService
    {
        private IStuCourseScheduleRepository _stuCourseScheduleRepository;

        public ShopService(IStuCourseScheduleRepository stuCourseScheduleRepository)
        {
            _stuCourseScheduleRepository = stuCourseScheduleRepository;
        }

        public async Task<bool> BookingCourseAsync(Guid userId, Guid courseScheduleId)
        {
            //verify duplicate schedule
            var schedule = await _stuCourseScheduleRepository.GetScheduleAsync(userId, courseScheduleId);

            if (schedule != null)
            {
                return false;
            }

            return await _stuCourseScheduleRepository.AddScheduleAsync(userId, courseScheduleId);
        }

        public async Task<bool> BookingDeleteAsync(Guid stuScheduleId)
        {
            return await _stuCourseScheduleRepository.DeleteScheduleAsync(stuScheduleId);
        }


        public async Task<List<StuCourseScheduleViewModel>> BookingListAsync(Guid userId)
        {
            return await _stuCourseScheduleRepository.GetScheduleAsync(userId);
        }
    }
}
