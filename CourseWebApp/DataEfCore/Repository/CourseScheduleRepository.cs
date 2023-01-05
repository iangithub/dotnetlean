using CoreLib.Interface;
using CoreLib.Models;
using DataEfCore.DbContextModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataEfCore.Repository
{
    public class CourseScheduleRepository : ICourseScheduleRepository
    {
        private KhNetCourseContext _dbcontext;

        public CourseScheduleRepository(KhNetCourseContext khNetCourseContext)
        {
            _dbcontext = khNetCourseContext;
        }
        public async Task<IEnumerable<CourseScheduleViewModel>> QueryAsync(CourseScheduleQueryCondition courseScheduleQueryCondition)
        {
            //note : using System.Linq
            var query = from sh in _dbcontext.Courseschedule
                        join c in _dbcontext.Course on sh.Courseid equals c.Id
                        join t in _dbcontext.Teacher on sh.Teacherid equals t.Id
                        select new CourseScheduleViewModel
                        {
                            Id = sh.Id,
                            CourseCode = c.Code,
                            CourseName = c.Name,
                            TeacherName = t.Name,
                            Sdate = sh.Sdate,
                            Edate = sh.Edate,
                            CourseTimes = c.Times,
                            CourseDesc = c.Description,
                            Location = sh.Location
                        };

            if (courseScheduleQueryCondition != null)
            {
                if (!string.IsNullOrEmpty(courseScheduleQueryCondition.CourseName))
                {
                    query = query.Where(c => c.CourseName.Contains(courseScheduleQueryCondition.CourseName));
                }
                if (!string.IsNullOrEmpty(courseScheduleQueryCondition.TeacherName))
                {
                    query = query.Where(t => t.TeacherName.Contains(courseScheduleQueryCondition.TeacherName));
                }
            }

            return await query.ToListAsync();
        }
    }
}
