using System;
using System.Windows;

namespace MarathonWPF
{
    /// <summary>
    /// Interaction logic for RecentRunResults.xaml
    /// </summary>
    public partial class RecentRunResults : Window
    {
        public RecentRunResults()
        {
            InitializeComponent();

            this.Loaded += RecentRunResults_Loaded;
        }

        private void RecentRunResults_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                genderCombo.ItemsSource = new g463_runnersDataSetTableAdapters.GenderTableAdapter().GetData();
                genderCombo.DisplayMemberPath = "Gender";
                genderCombo.SelectedValuePath = "Gender";

                marathonCombo.ItemsSource = new g463_runnersDataSetTableAdapters.Marathon1TableAdapter().GetData();
                marathonCombo.DisplayMemberPath = "YC";
                marathonCombo.SelectedValuePath = "MarathonId";

                //distanceCombo.ItemsSource

            } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void HandleBtnBack_Click(object sender, RoutedEventArgs e)
        {
            new DetailedInfo().Show();
            Close();
        }
    }
}
