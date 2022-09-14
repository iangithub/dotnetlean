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
using CoreLibrary.DbService;
using CourseWpfApp.Models;

namespace CourseWpfApp
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _dbConnStr;

        public MainWindow()
        {
            InitializeComponent();

            _dbConnStr = ((App)Application.Current).DbConnStr;
        }
      
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.Username.Text) || string.IsNullOrEmpty(this.Password.Password))
            {
                MessageBox.Show("請輸入帳號及密碼", "訊息");
                return;
            }

            var service = new AdminUserRepository(_dbConnStr);

            var user = service.GetAdminUser(this.Username.Text);

            if (user == null)
            {
                MessageBox.Show("登入失敗");
                return;
            }
            else
            {
                var reqHashPwd = LoginHelper.PwdHash(this.Password.Password, user.Id.ToString().ToUpper());

                if (reqHashPwd != user.Password)
                {
                    MessageBox.Show("登入失敗");
                    return;
                }

                var app = (App)Application.Current;
                app.CurrentUser = user;

                var menuWindow = new MenuWindow();
                menuWindow.Show();
                this.Close();
            }
        }
    }
}
