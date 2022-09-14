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
    /// AdminFunPage.xaml 的互動邏輯
    /// </summary>
    public partial class AdminFunPage : Page
    {
        private string _dbConnStr;
        private ObservableCollection<AdminUserInfo> _userList { get; set; }
        private AdminUserInfo _selectedUser;

        public AdminFunPage()
        {
            InitializeComponent();
            _dbConnStr = ((App)Application.Current).DbConnStr;
        }

        private void QueryUser_Click(object sender, RoutedEventArgs e)
        {
            var service = new AdminUserRepository(_dbConnStr);
            this.UserList.ItemsSource = service.Query(this.Query_User.Text, this.Query_Email.Text);
        }

        private void UserList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.UserList.SelectedItem != null)
            {
                this._selectedUser = (AdminUserInfo)this.UserList.SelectedItem;
                this.ShowDetail.DataContext = this._selectedUser;
            }
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            var create = new AdminFunCreate();
            create.ShowDialog();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this._selectedUser != null)
            {
                var service = new AdminUserRepository(_dbConnStr);
                service.UpdateAdminUser(_selectedUser);
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            //資料庫只剩一位管理員，不予刪除
            if (this._selectedUser != null)
            {
                var service = new AdminUserRepository(_dbConnStr);
                var adminCnt = service.Query(string.Empty, string.Empty).Count;

                if (adminCnt <= 1)
                {
                    MessageBox.Show("只剩一位系統管理員，不得刪除");
                }
                else
                {
                    service.DeleteAdminUser(_selectedUser);
                    this.ShowDetail.DataContext = null;
                    this.UserList.ItemsSource = service.Query(this.Query_User.Text, this.Query_Email.Text);
                }
            }
        }
    }
}
