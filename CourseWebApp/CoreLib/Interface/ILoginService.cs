using CoreLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.Interface
{
    public interface ILoginService
    {
        public Task<bool> UserRegisterAsync(Student user);
        public Task<Student> UserSignAsync(string email, string pwd);
    }
}
