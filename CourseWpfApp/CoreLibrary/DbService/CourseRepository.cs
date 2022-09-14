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
    public class CourseRepository
    {
        private string _connectionStrings;

        public CourseRepository(string connectionStrings)
        {
            _connectionStrings = connectionStrings;
        }

        public ObservableCollection<CourseInfo> Query()
        {
            var courseList = new ObservableCollection<CourseInfo>();

            using (var conn = new SqlConnection(_connectionStrings))
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select id,code,name,times,description from [dbo].[course]";
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var course = new CourseInfo();
                    course.Id = Guid.Parse(dr["id"].ToString());
                    course.Name = dr["name"].ToString();
                    course.Code = dr["code"].ToString();
                    course.Description = dr["description"].ToString();
                    course.Times = int.Parse(dr["times"].ToString());
                    courseList.Add(course);
                }
                dr.Close();
            }
            return courseList;
        }
    }
}
