using CoreLibrary.DataModels;
using CoreLibrary.DbService;
using CourseWpfApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// AdminFunCreate.xaml 的互動邏輯
    /// </summary>
    public partial class AdminFunCreate : Window
    {
        private string _dbConnStr;
        private AdminUserInfo _newAdminUser;

        public AdminFunCreate()
        {
            InitializeComponent();
            _dbConnStr = ((App)Application.Current).DbConnStr;
            _newAdminUser = new AdminUserInfo();
            this.DataContext = _newAdminUser;
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_newAdminUser.UserName))
            {
                MessageBox.Show("管理員帳號必填");
                return;
            }

            var service = new AdminUserRepository(_dbConnStr);

            //檢查User Name 是否重覆
            var user = service.GetAdminUser(_newAdminUser.UserName);

            if (user != null)
            {
                MessageBox.Show("管理員帳號重覆");
                return;
            }

            //密碼hash
            _newAdminUser.Id = Guid.NewGuid();
            _newAdminUser.Password = LoginHelper.PwdHash("123456", _newAdminUser.Id.ToString().ToUpper());


            service.CreateAdminUser(_newAdminUser);
            MessageBox.Show("資料新增成功");
        }
    }
}
