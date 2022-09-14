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
    public class TeacherRepository
    {
        private string _connectionStrings;
        public TeacherRepository(string connectionStrings)
        {
            _connectionStrings = connectionStrings;
        }

        public ObservableCollection<TeacherInfo> Query()
        {
            var teacherList = new ObservableCollection<TeacherInfo>();

            using (var conn = new SqlConnection(_connectionStrings))
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select id,name,email,mobile from [dbo].[teacher]";
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var teacher = new TeacherInfo();
                    teacher.Id = Guid.Parse(dr["id"].ToString());
                    teacher.Name = dr["name"].ToString();
                    teacher.Email = dr["email"].ToString();
                    teacher.Mobile = dr["mobile"].ToString();
                    teacherList.Add(teacher);
                }
                dr.Close();
            }
            return teacherList;
        }
    }
}
