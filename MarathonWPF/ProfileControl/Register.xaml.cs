using Microsoft.Win32;
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

            this.Loaded += Register_Loaded;
        }

        private void Register_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var genders = new g463_runnersDataSetTableAdapters.GenderTableAdapter().GetData();
                genderInp.ItemsSource = genders;
                genderInp.DisplayMemberPath = "Gender";
                genderInp.SelectedValuePath = "Gender";
                genderInp.SelectedIndex = 0;

                var countries = new g463_runnersDataSetTableAdapters.CountryTableAdapter().GetData();
                countryInp.ItemsSource = countries;
                countryInp.DisplayMemberPath = "CountryName";
                countryInp.SelectedValuePath = "CountryCode";
                countryInp.SelectedIndex = 0;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
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

        private void ViewImg_Click(object sender, RoutedEventArgs rea)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileOk += Ofd_FileOk;
            ofd.ShowDialog();
            ofd.Multiselect = false;

            void Ofd_FileOk(object s, System.ComponentModel.CancelEventArgs cea)
            {
                pathToImgInp.Text = ofd.FileName;
            }
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            string email = emailInp.Text;
            string firstName = firstNameInp.Text;
            string lastName = lastNameInp.Text;
            string gender = genderInp.SelectedValue.ToString();
            string pathImg = pathToImgInp.Text;
            ImageSource ava = (ImageSource)new ImageSourceConverter().ConvertFrom(File.ReadAllBytes(pathImg));
            string date = dateInp.SelectedDate.ToString();
            string country = countryInp.SelectedValue.ToString();
            string pass = passInp.Password;
            if(passRight)
            {
                //new g463_runnersDataSetTableAdapters.
            }
        }

        private void PassRInp_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if(passInp.Password != passRInp.Password)
            {
                passRInp.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                passRInp.BorderBrush = new SolidColorBrush(Colors.Gray);
            }
        }
    }
}
