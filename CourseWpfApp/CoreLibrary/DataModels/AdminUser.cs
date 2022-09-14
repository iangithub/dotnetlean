using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary.DataModels
{
    public class AdminUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }


    public class AdminUserInfo
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

}
