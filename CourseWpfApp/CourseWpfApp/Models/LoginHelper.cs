﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CourseWpfApp.Models
{
    public static class LoginHelper
    {
        public static string PwdHash(string pwd, string salt)
        {
            var result = string.Empty;
            using (var sha256 = new SHA256CryptoServiceProvider())
            {
                //將字串編碼成 UTF8 bytes[]
                var bytes = Encoding.UTF8.GetBytes(pwd + salt);

                //取得雜湊值bytes[]
                var hash = sha256.ComputeHash(bytes);

                //byte[] to base64 string
                result = Convert.ToBase64String(hash);
            }
            return result;
        }
    }
}
