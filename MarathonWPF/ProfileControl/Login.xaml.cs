using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MarathonWPF
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void HandleBtnBack_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (t.Tag == null)
            {
                t.Tag = t.Text;
                t.Text = "";
            }
            else
            {
                if ((string)t.Tag == t.Text) t.Text = "";
            }
            t.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (t.Text == "")
            {
                t.Text = (string)t.Tag;
                t.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string email = emailInp.Text;
            string pass = passInp.Password;
            try
            {
                var user = new g463_runnersDataSetTableAdapters.UserTableAdapter().GetUser(email, pass).ElementAt(0);

                UserData.userEmail = email;
                UserData.userRole = user.RoleId;

                switch (UserData.userRole)
                {
                    case "A":
                        new MenuAdmin().Show();
                        Close();
                        break;
                    case "C":
                        new MenuCoordinator().Show();
                        Close();
                        break;
                    case "R":
                        new MenuRunner().Show();
                        Close();
                        break;
                    default:
                        MessageBox.Show("Неизвестная роль!");
                        break;
                }
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message, "Произошла ошибка!", MessageBoxButton.OK, MessageBoxImage.Error); }
            
        }
    }
}
