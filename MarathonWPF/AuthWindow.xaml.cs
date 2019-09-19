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
    /// Interaction logic for auth.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void HandleBtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void HandleBtnLogin_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Login().ShowDialog();
            this.Show();
        }

        private void HandleBtnRegister_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Register().ShowDialog();
            this.Show();
        }
    }
}
