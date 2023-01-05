using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLib.Models
{
    public class StudentPwdReqModel
    {
        public Guid Id { get; set; }
        public string NewPwd { get; set; }
        public string OldPwd { get; set; }
    }
}
