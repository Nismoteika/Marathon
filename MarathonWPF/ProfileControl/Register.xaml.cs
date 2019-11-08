using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MarathonWPF
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private bool passRight;

        public Register()
        {
            InitializeComponent();
        }

        private void HandleBtnBack_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
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

        private void ViewImg_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            string email = emailInp.Text;
            string firstName = firstNameInp.Text;
            string lastName = lastNameInp.Text;
            string gender = genderInp.Text;
            string pathImg = pathToImgInp.Text;
            byte[] ava = File.ReadAllBytes(pathImg);
            DateTime? date = dateInp.SelectedDate;
            string country = countryInp.Text;
            string pass = passInp.Password;
            if(passRight && date != null)
            {
                new g463_runnersDataSetTableAdapters.UserTableAdapter().Insert(email, pass, firstName, lastName, "R");
                new g463_runnersDataSetTableAdapters.RunnerTableAdapter().Insert(email, gender, date, country);
            }
        }

        private void PassRInp_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if(passInp.Password != passRInp.Password)
            {
                passRInp.BorderBrush = new SolidColorBrush(Colors.Red);
            }
        }
    }
}
