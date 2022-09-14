using CoreLibrary.DataModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary.DbService
{
    public class AdminUserRepository
    {
        private string _connectionStrings;
        public AdminUserRepository(string connectionStrings)
        {
            _connectionStrings = connectionStrings;
        }

        public AdminUserInfo GetAdminUser(string username)
        {
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
                    user = new AdminUserInfo()
                    {
                        Id = Guid.Parse(dr["id"].ToString()),
                        Password = dr["password"].ToString(),
                        UserName = dr["username"].ToString(),
                        Email = dr["email"].ToString()
                    };
                }
                dr.Close();
            }
            return user;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">User Id</param>
        /// <param name="newPwd">hashpwd</param>
        public void UpdatePwd(Guid id, string newPwd)
        {
            using (var conn = new SqlConnection(_connectionStrings))
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "update sysadmin set password=@password where id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@password", newPwd);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public ObservableCollection<AdminUserInfo> Query(string userName, string email)
        {
            var userList = new ObservableCollection<AdminUserInfo>();

            using (var conn = new SqlConnection(_connectionStrings))
            {
                var cmd = new SqlCommand();

                string querySql = "Select id,username,password,email from sysadmin ";
                string where = string.Empty;

                if (!string.IsNullOrEmpty(userName))
                {
                    where += " username=@userName ";

                    cmd.Parameters.AddWithValue("@userName", userName);
                }

                if (!string.IsNullOrEmpty(email))
                {
                    if (!string.IsNullOrEmpty(where))
                    {
                        where += " and ";
                    }

                    where += " email=@email ";

                    cmd.Parameters.AddWithValue("@email", email);
                }

                if (!string.IsNullOrEmpty(where))
                {
                    querySql += " where " + where;
                }

                cmd.CommandText = querySql;
                cmd.Connection = conn;
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var user = new AdminUserInfo();
                    user.Id = Guid.Parse(dr["id"].ToString());
                    user.UserName = dr["username"].ToString();
                    user.Email = dr["email"].ToString();

                    userList.Add(user);
                }

            }

            return userList;
        }


        public void CreateAdminUser(AdminUserInfo adminUserInfo)
        {
            using (var conn = new SqlConnection(_connectionStrings))
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"insert into sysadmin (id,username,password,email,initdate) 
values(@id,@username,@password,@email,getdate()) ";
                cmd.Parameters.AddWithValue("@id", adminUserInfo.Id);
                cmd.Parameters.AddWithValue("@username", adminUserInfo.UserName);
                cmd.Parameters.AddWithValue("@password", adminUserInfo.Password);
                if (string.IsNullOrEmpty(adminUserInfo.Email))
                {
                    cmd.Parameters.AddWithValue("@email", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@email", adminUserInfo.Email);
                }
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateAdminUser(AdminUserInfo adminUserInfo)
        {
            using (var conn = new SqlConnection(_connectionStrings))
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "update sysadmin set email=@email where id=@id";
                cmd.Parameters.AddWithValue("@id", adminUserInfo.Id);
                cmd.Parameters.AddWithValue("@email", adminUserInfo.Email);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteAdminUser(AdminUserInfo adminUserInfo)
        {
            using (var conn = new SqlConnection(_connectionStrings))
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "delete sysadmin where id=@id";
                cmd.Parameters.AddWithValue("@id", adminUserInfo.Id);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
