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
        private bool passRight = false;

        public Register()
        {
            InitializeComponent();
            this.Loaded += Register_Loaded;
        }

        private void Register_Loaded(object sender, RoutedEventArgs e)
        {
            var genderData = new g463_runnersDataSetTableAdapters.GenderTableAdapter().GetData();
            genderCombo.ItemsSource = genderData;
            genderCombo.DisplayMemberPath = "Gender";
            genderCombo.SelectedValuePath = "Gender";

            var countryData = new g463_runnersDataSetTableAdapters.CountryTableAdapter().GetData();
            countryCombo.ItemsSource = countryData;
            countryCombo.DisplayMemberPath = "CountryName";
            countryCombo.SelectedValuePath = "CountryCode";
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
            //gender
            string pathImg = pathToImgInp.Text;
            byte[] ava = File.ReadAllBytes(pathImg);
            DateTime? date = dateInp.SelectedDate;
            //string country = countryInp.Text;
            string pass = passInp.Password;
            if(passRight && date != null)
            {
                int ans1 = new g463_runnersDataSetTableAdapters.UserTableAdapter().Insert(email, pass, firstName, lastName, "R", ava);
                int ans2 = new g463_runnersDataSetTableAdapters.RunnerTableAdapter().Insert(email, genderCombo.SelectedItem.ToString(), date, countryCombo.SelectedItem.ToString());
                if(ans1 == 1)
                {
                    if(ans2 == 1)
                    {
                        MessageBox.Show("Success runner inserted");
                    } else
                    {
                        Console.WriteLine("can't insert runner");
                    }

                } else
                {
                    Console.WriteLine("can't insert user");
                }

            }

        }

        private void PassRInp_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if(passInp.Password != passRInp.Password)
            {
                passRInp.BorderBrush = new SolidColorBrush(Colors.Red);
                passRight = false;
            } else
            {
                passRInp.BorderBrush = new SolidColorBrush(Colors.Green);
                passRight = true;
            }
        }
    }
}
