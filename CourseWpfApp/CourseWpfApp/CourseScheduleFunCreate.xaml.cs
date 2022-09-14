using CoreLibrary.DataModels;
using CoreLibrary.DbService;
using CourseWpfApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CourseWpfApp
{
    /// <summary>
    /// CourseScheduleFunCreate.xaml 的互動邏輯
    /// </summary>
    public partial class CourseScheduleFunCreate : Window
    {
        private string _dbConnStr;
        private CourseScheduleCreateModel _newCourseSchedule;
        public CourseScheduleFunCreate()
        {
            InitializeComponent();
            _dbConnStr = ((App)Application.Current).DbConnStr;
            _newCourseSchedule = new CourseScheduleCreateModel();
            this.DataContext = _newCourseSchedule;
            ComboxBind();
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {

            _newCourseSchedule.Cid = ((CourseInfo)this.CourseCombo.SelectedItem).Id;
            _newCourseSchedule.Tid = ((TeacherInfo)this.TeacherCombo.SelectedItem).Id;

            if (_newCourseSchedule.Cid == Guid.Empty)
            {
                MessageBox.Show("課程必填");
                return;
            }

            if (_newCourseSchedule.Tid == Guid.Empty)
            {
                MessageBox.Show("講師必填");
                return;
            }

            if (string.IsNullOrEmpty(_newCourseSchedule.Location))
            {
                MessageBox.Show("課程地點必填");
                return;
            }

            var service = new CourseScheduleRepository(_dbConnStr);
            service.CreateCourseSchedule(_newCourseSchedule);
            MessageBox.Show("資料新增成功");
        }

        private void ComboxBind()
        {
            var cousreService = new CourseRepository(_dbConnStr);
            this.CourseCombo.ItemsSource = cousreService.Query();

            var teaService = new TeacherRepository(_dbConnStr);
            this.TeacherCombo.ItemsSource = teaService.Query();

        }
    }
}
