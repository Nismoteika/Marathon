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
    /// Логика взаимодействия для RegisterOnMarathon.xaml
    /// </summary>
    public partial class RegisterOnMarathon : Window
    {
        public RegisterOnMarathon()
        {
            InitializeComponent();

            this.Loaded += RegisterOnMarathon_Loaded;
        }

        private void RegisterOnMarathon_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var founds = new g463_runnersDataSetTableAdapters.CharityTableAdapter().GetDataWithoutLogo();
                foundComboBox.ItemsSource = founds;
                foundComboBox.DisplayMemberPath = "CharityDescription";
                foundComboBox.SelectedValuePath = "CharityId";
                foundComboBox.SelectedIndex = 0;
            } 
            catch { }
        }

        private void HandleBtnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            recount();
        }

        private void RB_Checked(object sender, RoutedEventArgs e)
        {
            recount();
        }

        private void recount()
        {
            int sum = 0;

            if (RB0.IsChecked == true) sum += Convert.ToInt32(RB0.Tag);
            if (RB1.IsChecked == true) sum += Convert.ToInt32(RB1.Tag);
            if (RB2.IsChecked == true) sum += Convert.ToInt32(RB2.Tag);

            if (CB0.IsChecked == true) sum += Convert.ToInt32(CB0.Tag);
            if (CB1.IsChecked == true) sum += Convert.ToInt32(CB1.Tag);
            if (CB2.IsChecked == true) sum += Convert.ToInt32(CB2.Tag);

            SumLabel.Content = "$" + sum.ToString();
        }
    }
}
