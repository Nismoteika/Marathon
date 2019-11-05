using System.Windows;

namespace MarathonWPF
{
    /// <summary>
    /// Interaction logic for ListFonds.xaml
    /// </summary>
    public partial class ListFonds : Window
    {
        public ListFonds()
        {
            InitializeComponent();

            this.Loaded += ListFonds_Loaded;
        }

        private void ListFonds_Loaded(object sender, RoutedEventArgs e)
        {
            g463_runnersDataSet.CharityDataTable data = new g463_runnersDataSetTableAdapters.CharityTableAdapter().GetData();
            for(int i = 0; i < data.Count; i++)
            {
                g463_runnersDataSet.CharityRow element = data[i];
                Fond fond = new Fond(element.CharityName, element.CharityDescription, element.CharityLogo);
                stackFonds.Children.Add(fond);
            }
        }

        private void HandleBtnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
            new MainWindow().Show();
        }


    }
}
