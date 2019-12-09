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
        int marCat1S;
        int marCat2S;
        int marCat3S;

        int marVarBS;
        int marVarCS;

        int result;

        public RegisterOnMarathon()
        {
            InitializeComponent();
            this.Loaded += RegisterOnMarathon_Loaded;
        }

        private void RegisterOnMarathon_Loaded(object sender, RoutedEventArgs e)
        {
            var charitys = new g463_runnersDataSetTableAdapters.CharityTableAdapter().GetData();
            charityCombo.ItemsSource = charitys;
            charityCombo.DisplayMemberPath = "CharityName";
            charityCombo.SelectedValuePath = "CharityId";
        }

        private void updateSummary(object sender, RoutedEventArgs e)
        {
            int marCat1V = 145;
            int marCat2V = 75;
            int marCat3V = 20;

            int marCat1B = marCat1.IsChecked == true ? 1 : 0;
            int marCat2B = marCat2.IsChecked == true ? 1 : 0;
            int marCat3B = marCat3.IsChecked == true ? 1 : 0;

            marCat1S = marCat1V * marCat1B;
            marCat2S = marCat2V * marCat2B;
            marCat3S = marCat3V * marCat3B;

            int marVarBV = 20;
            int marVarCV = 45;

            int marVarBB = marVarB.IsChecked == true ? 1 : 0;
            int marVarCB = marVarC.IsChecked == true ? 1 : 0;

            marVarBS = marVarBV * marVarBB;
            marVarCS = marVarCV * marVarCB;

            result = marCat1S + marCat2S + marCat3S + marVarBS + marVarCS;
            summaryLabel.Content = result.ToString() + "$";
        }

        private void HandleBtnBack_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow();
            Close();
        }

        private void HandleRegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (marCat1S > 0 || marCat2S > 0 || marCat3S > 0)
            {
                new g463_runnersDataSetTableAdapters.RegistrationTableAdapter().InsertQuery()
            }
        }

        private void SumInp_KeyDown(object sender, KeyEventArgs e)
        {
        }
    }
}
