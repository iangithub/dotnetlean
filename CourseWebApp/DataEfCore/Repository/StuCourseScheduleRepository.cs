using CoreLib.Interface;
using CoreLib.Models;
using DataEfCore.DbContextModels;
using DataEfCore.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEfCore.Repository
{
    public class StuCourseScheduleRepository : IStuCourseScheduleRepository
    {
        private KhNetCourseContext _dbcontext;

        public StuCourseScheduleRepository(KhNetCourseContext khNetCourseContext)
        {
            _dbcontext = khNetCourseContext;
        }

        public async Task<bool> AddScheduleAsync(Guid userId, Guid courseScheduleId)
        {
            var entity = new Stucourseschedule()
            {
                Id = Guid.NewGuid(),
                Studentid = userId,
                Cscheduleid = courseScheduleId
            };

            await _dbcontext.Stucourseschedule.AddAsync(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteScheduleAsync(Guid stuScheduleId)
        {
            var entity = await _dbcontext.Stucourseschedule.Where(s => s.Id == stuScheduleId).FirstOrDefaultAsync();

            if (entity != null)
            {
                _dbcontext.Stucourseschedule.Remove(entity);
            }
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<StuCourseScheduleViewModel> GetScheduleAsync(Guid userId, Guid courseScheduleId)
        {
            var query = from stusch in _dbcontext.Stucourseschedule
                        join coursesch in _dbcontext.Courseschedule on stusch.Cscheduleid equals coursesch.Id
                        join c in _dbcontext.Course on coursesch.Courseid equals c.Id
                        join t in _dbcontext.Teacher on coursesch.Teacherid equals t.Id
                        where stusch.Studentid == userId
                        && stusch.Cscheduleid == courseScheduleId
                        select new StuCourseScheduleViewModel
                        {
                            Id = stusch.Id,
                            CourseSchueduleId = stusch.Cscheduleid,
                            CourseName = c.Name,
                            TeacherName = t.Name,
                            Sdate = coursesch.Sdate,
                            Edate = coursesch.Edate
                        };

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<StuCourseScheduleViewModel>> GetScheduleAsync(Guid userId)
        {
            var query = from stusch in _dbcontext.Stucourseschedule
                        join coursesch in _dbcontext.Courseschedule on stusch.Cscheduleid equals coursesch.Id
                        join c in _dbcontext.Course on coursesch.Courseid equals c.Id
                        join t in _dbcontext.Teacher on coursesch.Teacherid equals t.Id
                        where stusch.Studentid == userId
                        select new StuCourseScheduleViewModel
                        {
                            Id = stusch.Id,
                            CourseSchueduleId = stusch.Cscheduleid,
                            CourseName = c.Name,
                            TeacherName = t.Name,
                            Sdate = coursesch.Sdate,
                            Edate = coursesch.Edate
                        };

            return await query.ToListAsync();
        }
    }
}
