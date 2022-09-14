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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CourseWpfApp
{
    /// <summary>
    /// PwdFunPage.xaml 的互動邏輯
    /// </summary>
    public partial class PwdFunPage : Page
    {
        private string _dbConnStr;
        public PwdFunPage()
        {
            InitializeComponent();
            _dbConnStr = ((App)Application.Current).DbConnStr;
        }

        private void PwdChgBtn_Click(object sender, RoutedEventArgs e)
        {
            var user = ((App)Application.Current).CurrentUser;
            var oldHashPwd = LoginHelper.PwdHash(this.OldPwd.Password, user.Id.ToString().ToUpper());
            var newHashPwd = LoginHelper.PwdHash(this.NewPwd.Password, user.Id.ToString().ToUpper());
            //var confirmHashPwd = LoginHelper.PwdHash(this.ConfirmPwd.Password, user.Id.ToString().ToUpper());

            if (oldHashPwd != user.Password)
            {
                MessageBox.Show("原始密碼錯誤");
            }
            else
            {
                if (this.NewPwd.Password!=this.ConfirmPwd.Password)
                {
                    MessageBox.Show("2次新密碼不一樣");
                }
                else
                {
                    var service = new AdminUserRepository(_dbConnStr);
                    service.UpdatePwd(user.Id, newHashPwd);
                    MessageBox.Show("密碼變更完成");
                }
            }
        }
    }
}
