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
    public partial class EarlyOrNow : Window
    {
        public EarlyOrNow()
        {
            InitializeComponent();
        }

        private void HandleBtnBack_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void HandleBtnLogin_Click(object sender, RoutedEventArgs e)
        {
            new Login().Show();
            Close();
        }

        private void HandleBtnRegister_Click(object sender, RoutedEventArgs e)
        {
            new Register().Show();
            Close();
        }
    }
}
