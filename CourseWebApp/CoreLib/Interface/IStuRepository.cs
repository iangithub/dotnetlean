using CoreLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.Interface
{
    public interface IStuRepository
    {

        Task<bool> CreateAsync(Student user);
        Task<Student> QueryAsync(string email);
        Task<Student> GetStuAsync(Guid id);
        Task<bool> UpdateStuPwdAsync(Guid id, string newPwd);
        Task<bool> UpdateStuAsync(Student user);

    }
}
