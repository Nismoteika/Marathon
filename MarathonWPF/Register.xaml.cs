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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void HandleBtnBack_Click(object sender, RoutedEventArgs e)
        {
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
    }
}
