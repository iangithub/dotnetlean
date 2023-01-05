using CoreLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.Interface
{
    public interface IMemberService
    {
        public Task<bool> MemberPwdUpdateAsync(StudentPwdReqModel studentPwdReqModel);
        public Task<bool> MemberUpdateAsync(Student student);

    }
}
