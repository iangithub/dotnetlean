using CoreLibrary.DataModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary.DbService
{
    public class LoginService
    {
        private string _connectionStrings;
        public LoginService(string connectionStrings)
        {
            _connectionStrings = connectionStrings;
        }

        public AdminUserInfo VerifyUser(string username, string pwd)
        {
            var dbHashPwd = string.Empty;
            var reqHashPwd = string.Empty;
            AdminUserInfo user = null;

            using (var conn = new SqlConnection(_connectionStrings))
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from sysadmin where username=@username";
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dbHashPwd = dr["password"].ToString();
                    reqHashPwd = PwdHash(pwd, dr["id"].ToString().ToUpper());

                    if (reqHashPwd == dbHashPwd)
                    {
                        user = new AdminUserInfo()
                        {
                            Id = Guid.Parse(dr["id"].ToString()),
                            UserName = dr["username"].ToString(),
                            Email = dr["email"].ToString()
                        };
                    }
                }
                dr.Close();
            }

            return user;
        }

        private string PwdHash(string pwd, string salt)
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
