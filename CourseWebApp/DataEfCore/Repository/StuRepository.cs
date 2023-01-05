using CoreLib.Interface;
using CoreLib.Models;
using DataEfCore.DbContextModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEfCore.Repository
{
    public class StuRepository : IStuRepository
    {
        private KhNetCourseContext _khNetCourseContext;

        public StuRepository(KhNetCourseContext khNetCourseContext)
        {
            _khNetCourseContext = khNetCourseContext;
        }

        public async Task<bool> CreateAsync(Student user)
        {
            await _khNetCourseContext.Student.AddAsync(new EntityModels.Student()
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.UserName,
                Password = user.Pwd
            });

            await _khNetCourseContext.SaveChangesAsync();

            return true;
        }



        public async Task<Student> QueryAsync(string email)
        {
            var stu = await _khNetCourseContext.Student
                .Where(x => x.Email.ToUpper() == email.ToUpper()).FirstOrDefaultAsync();

            if (stu == null)
            {
                return null;
            }

            return new Student()
            {
                Id = stu.Id,
                Email = stu.Email,
                UserName = stu.Name,
                Pwd = stu.Password
            };
        }

        public async Task<bool> UpdateStuAsync(Student user)
        {
            var entity = await _khNetCourseContext.Student.Where(u => u.Id == user.Id).FirstOrDefaultAsync();
            if (entity != null)
            {
                entity.Name = user.UserName;
                entity.Mobile = user.Mobile;
                await _khNetCourseContext.SaveChangesAsync();
            }

            return true;
        }

        public async Task<bool> UpdateStuPwdAsync(Guid id, string newPwd)
        {
            var entity = await _khNetCourseContext.Student.Where(u => u.Id == id).FirstOrDefaultAsync();
            if (entity != null)
            {
                entity.Password = newPwd;
                await _khNetCourseContext.SaveChangesAsync();
            }

            return true;

        }
        public async Task<Student> GetStuAsync(Guid id)
        {
            var entity = await _khNetCourseContext.Student.Where(u => u.Id == id).FirstOrDefaultAsync();
            if (entity == null)
                return null;

            return new Student() { Id = entity.Id, UserName = entity.Name, Email = entity.Email, Pwd = entity.Password };
        }
    }
}
