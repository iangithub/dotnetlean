using CoreLib.Helper;
using CoreLib.Interface;
using CoreLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.Service
{
    public class MemberService : IMemberService
    {
        private IStuRepository _stuRepository;

        public MemberService(IStuRepository stuRepository)
        {
            _stuRepository = stuRepository;
        }
        public async Task<bool> MemberPwdUpdateAsync(StudentPwdReqModel studentPwdReqModel)
        {
            var user = await _stuRepository.GetStuAsync(studentPwdReqModel.Id);
            if (user == null) return false;

            var hashPwd = PwdService.PwdSHA256Hash(studentPwdReqModel.OldPwd, studentPwdReqModel.Id.ToString());
            if (hashPwd != user.Pwd) return false;


            var newHashPwd = PwdService.PwdSHA256Hash(studentPwdReqModel.NewPwd, studentPwdReqModel.Id.ToString());

            await _stuRepository.UpdateStuPwdAsync(studentPwdReqModel.Id, newHashPwd);
            return true;
        }

        public Task<bool> MemberUpdateAsync(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
