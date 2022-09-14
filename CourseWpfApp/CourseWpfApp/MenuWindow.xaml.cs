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
    /// MenuWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();

            double screenH = SystemParameters.FullPrimaryScreenHeight;
            double screenW = SystemParameters.FullPrimaryScreenWidth;

            this.Width = screenW;
            this.Height = screenH;

            //視窗顯示在中央
            this.Top = (screenH - this.Height) / 2;
            this.Left = (screenW - this.Width) / 2;

            this.User.Text = $"使用者: {((App)Application.Current).CurrentUser.UserName}";
        }

        private void AdminFun_Click(object sender, RoutedEventArgs e)
        {
            this.FunFrame.Navigate(new System.Uri("AdminFunPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void StuFun_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TeaFun_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CourseFun_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CourseScheduleFun_Click(object sender, RoutedEventArgs e)
        {
            this.FunFrame.Navigate(new System.Uri("CourseScheduleFunPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void PwdFun_Click(object sender, RoutedEventArgs e)
        {
            this.FunFrame.Navigate(new System.Uri("PwdFunPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void LogoutFun_Click(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).CurrentUser = null;
            var login = new MainWindow();
            login.Show();
            this.Close();
        }
    }
}
