using CoreLibrary.DataModels;
using CoreLibrary.DbService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CourseWpfApp
{
    /// <summary>
    /// CourseScheduleFunPage.xaml 的互動邏輯
    /// </summary>
    public partial class CourseScheduleFunPage : Page
    {
        private string _dbConnStr;
        private ObservableCollection<CourseScheduleInfo> _courseList { get; set; }
        private CourseScheduleInfo _selectedCourse;

        public CourseScheduleFunPage()
        {
            InitializeComponent();
            _dbConnStr = ((App)Application.Current).DbConnStr;
        }

        private void Query_Click(object sender, RoutedEventArgs e)
        {
            var service = new CourseScheduleRepository(_dbConnStr);
            this.InfoList.ItemsSource = service.Query(this.Query_CName.Text, this.Query_TName.Text);
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            var create = new CourseScheduleFunCreate();
            create.ShowDialog();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void InfoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.InfoList.SelectedItem != null)
            {
                this._selectedCourse = (CourseScheduleInfo)this.InfoList.SelectedItem;
                this.ShowDetail.DataContext = this._selectedCourse;
            }
        }
    }
}
