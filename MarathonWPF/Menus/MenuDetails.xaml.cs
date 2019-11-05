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
    /// Логика взаимодействия для DetailedInfo.xaml
    /// </summary>
    public partial class DetailedInfo : Window
    {
        public DetailedInfo()
        {
            InitializeComponent();

            this.Loaded += DetailedInfo_Loaded;
        }

        private void DetailedInfo_Loaded(object sender, RoutedEventArgs e)
        {
            new HandleBack(this, handleBtnBack);
        }

        private void ListFondsBtn_Click(object sender, RoutedEventArgs e)
        {
            new ListFonds().Show();
            Close();

        }

        private void TableRecentRuns_Click(object sender, RoutedEventArgs e)
        {
            new RecentRunResults().Show();
            Close();
        }
    }
}
