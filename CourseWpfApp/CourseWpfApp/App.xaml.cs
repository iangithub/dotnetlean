using CoreLibrary.DataModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CourseWpfApp
{
    /// <summary>
    /// App.xaml 的互動邏輯
    /// </summary>
    public partial class App : Application
    {
        public String DbConnStr { get; set; }= ConfigurationManager.ConnectionStrings["CourseDB"].ConnectionString;
        public AdminUserInfo CurrentUser { get; set; }
    }
}
