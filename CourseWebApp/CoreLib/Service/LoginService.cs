using CoreLib.Helper;
using CoreLib.Interface;
using CoreLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.Service
{
    public class LoginService : ILoginService
    {
        private IStuRepository _stuRepository;

        public LoginService(IStuRepository stuRepository)
        {
            _stuRepository = stuRepository;
        }


        public async Task<bool> UserRegisterAsync(Student user)
        {
            user.Id = Guid.NewGuid();

            //檢查重覆註冊
            var stu = await _stuRepository.QueryAsync(user.Email);

            if (stu != null)
            {
                return false;
            }

            //密碼hash
            user.Pwd = CoreLib.Helper.PwdService.PwdSHA256Hash(user.Pwd, user.Id.ToString());

            //Write to DB
            return await _stuRepository.CreateAsync(user);
        }

        public async Task<Student> UserSignAsync(string email, string pwd)
        {
            //query student by email
            var dbstu = await _stuRepository.QueryAsync(email);
            if (dbstu == null)
            {
                return null;
            }

            //verify hash pwd
            var hashPwd = CoreLib.Helper.PwdService.PwdSHA256Hash(pwd, dbstu.Id.ToString());

            if (hashPwd != dbstu.Pwd)
            {
                return null;
            }

            return dbstu;
        }
    }
}
