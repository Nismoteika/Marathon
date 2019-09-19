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
    }
}
