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

namespace MarathonWPF
{
    /// <summary>
    /// Логика взаимодействия для ThanksSponsorSupport.xaml
    /// </summary>
    public partial class ThanksSponsorSupport : Window
    {
        private decimal muchDollars;
        private string runner;

        public ThanksSponsorSupport(string runner, decimal muchDollars)
        {
            this.runner = runner;
            this.muchDollars = muchDollars;
            InitializeComponent();

            this.Loaded += ThanksSponsorSupport_Loaded;
        }

        private void ThanksSponsorSupport_Loaded(object sender, RoutedEventArgs e)
        {
            labelRunner.Content = runner;
            labelMuchDollars.Content = "$" + muchDollars;
        }

        private void HandleBtnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
            new MainWindow().Show();
        }
    }
}
