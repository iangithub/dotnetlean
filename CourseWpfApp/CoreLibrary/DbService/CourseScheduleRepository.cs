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
    public class CourseScheduleRepository
    {

        private string _connectionStrings;
        public CourseScheduleRepository(string connectionStrings)
        {
            _connectionStrings = connectionStrings;
        }


        public ObservableCollection<CourseScheduleInfo> Query(string courseName, string teacherName)
        {
            var courseList = new ObservableCollection<CourseScheduleInfo>();

            using (var conn = new SqlConnection(_connectionStrings))
            {
                var cmd = new SqlCommand();

                string querySql = @"select schedule.id,course.code,course.name,teacher.name as tname
,schedule.sdate,schedule.edate,course.times,schedule.location,course.description
from courseschedule as schedule
inner join course on schedule.courseid=course.id
inner join teacher on schedule.teacherid=teacher.id ";

                string where = string.Empty;

                if (!string.IsNullOrEmpty(courseName))
                {
                    where += " course.name like @coursename ";

                    cmd.Parameters.AddWithValue("@coursename", $"%{courseName}%");
                }

                if (!string.IsNullOrEmpty(teacherName))
                {
                    if (!string.IsNullOrEmpty(where))
                    {
                        where += " and ";
                    }

                    where += " teacher.name like @teachername ";

                    cmd.Parameters.AddWithValue("@teachername", $"%{teacherName}%");
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
                    var cschedule = new CourseScheduleInfo();
                    cschedule.Id = Guid.Parse(dr["id"].ToString());
                    cschedule.Code = dr["code"].ToString();
                    cschedule.Name = dr["name"].ToString();
                    cschedule.TeacherName = dr["tname"].ToString();
                    cschedule.Sdate = DateTime.Parse(dr["sdate"].ToString());
                    cschedule.Edate = DateTime.Parse(dr["edate"].ToString());
                    cschedule.Times = int.Parse(dr["times"].ToString());
                    cschedule.Location = dr["location"].ToString();
                    cschedule.Description = dr["description"].ToString();

                    courseList.Add(cschedule);
                }

            }
            return courseList;
        }

        public void CreateCourseSchedule(CourseScheduleCreateModel courseScheduleCreateModel)
        {
            using (var conn = new SqlConnection(_connectionStrings))
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"insert into courseschedule (id,courseid,teacherid,sdate,edate,location) 
values(@id,@courseid,@teacherid,@sdate,@edate,@location) ";

                cmd.Parameters.AddWithValue("@id", courseScheduleCreateModel.Id);
                cmd.Parameters.AddWithValue("@courseid", courseScheduleCreateModel.Cid);
                cmd.Parameters.AddWithValue("@teacherid", courseScheduleCreateModel.Tid);
                cmd.Parameters.AddWithValue("@sdate", courseScheduleCreateModel.Sdate);
                cmd.Parameters.AddWithValue("@edate", courseScheduleCreateModel.Edate);
                cmd.Parameters.AddWithValue("@location", courseScheduleCreateModel.Location);

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
