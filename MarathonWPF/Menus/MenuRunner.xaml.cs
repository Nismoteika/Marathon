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
    /// Логика взаимодействия для MenuRunner.xaml
    /// </summary>
    public partial class MenuRunner : Window
    {
        public MenuRunner()
        {
            InitializeComponent();
        }

        private void HandleBtnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new RegisterOnMarathon().Show();
            this.Close();
        }
    }
}
