using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MarathonWPF
{
    /// <summary>
    /// Логика взаимодействия для SponsorRunner.xaml
    /// </summary>
    public partial class SponsorRunner : Window
    {
        private decimal muchDollars = 50;
        private string sName;

        public SponsorRunner()
        {
            InitializeComponent();

            Loaded += SponsorRunner_Loaded;
        }

        private void SponsorRunner_Loaded(object sender, RoutedEventArgs e)
        {
            RevTimer revTimer = new RevTimer(ReverseTimer);
            //
            runnerName.ItemsSource = new g463_runnersDataSetTableAdapters.User1TableAdapter().GetData();
            runnerName.DisplayMemberPath = "FN";
            runnerName.SelectedValuePath = "RunnerId";
        }

        private void HandleBtnBack_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void DecreseDollars_Click(object sender, RoutedEventArgs e)
        {
            if (muchDollars - 10 > 0)
            {
                muchDollars -= 10;
                labelMuchDollars.Content = "$" + muchDollars;
                textMuchDollars.Text = Convert.ToString(muchDollars);
            }
        }

        private void IncreseDollars_Click(object sender, RoutedEventArgs e)
        {
            muchDollars += 10;
            labelMuchDollars.Content = "$" + muchDollars;
            textMuchDollars.Text = Convert.ToString(muchDollars);
        }

        private void TextMuchDollars_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                muchDollars = Convert.ToDecimal(textMuchDollars.Text);
                if(muchDollars < 0)
                    muchDollars *= -1;
                    
                labelMuchDollars.Content = "$" + muchDollars.ToString();
            } catch
            {
                MessageBox.Show("Введите число (желательно положительное)");
            }
        }

        private void PayToRunner_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int val = Convert.ToInt32(runnerName.SelectedValue);
                int ans = new g463_runnersDataSetTableAdapters.SponsorshipTableAdapter().InsertQuery(sName, val, muchDollars);
                if(ans == 1)
                {
                    new ThanksSponsorSupport(runnerName.Text, muchDollars).Show();
                    Close();
                }

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SponsorName_TextChanged(object sender, TextChangedEventArgs e)
        {
            sName = sponsorName.Text;
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

        private void NameCart_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void NumCart_TextChanged(object sender, TextChangedEventArgs e)
        {
           TextBox el = (TextBox)sender;
           if (numCart.Text != "Номер карты")
                if (!Regex.IsMatch(el.Text, "^[0-9]{4}-[0-9]{4}-[0-9]{4}-[0-9]{4}$"))
                {
                    el.BorderBrush = new SolidColorBrush(Colors.Red);
                } else
                {
                    el.BorderBrush = new SolidColorBrush(Colors.Gray);
                }
        }
    }
}
