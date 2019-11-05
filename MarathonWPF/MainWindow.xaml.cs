using System;
using System.Windows;
using System.Windows.Threading;

namespace MarathonWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RevTimer revTimer = new RevTimer(ReverseTimer);
        }

        private void HandleBtnAuthWindowOpen_Click(object sender, RoutedEventArgs e)
        {
            new Login().Show();
            Close();
        }

        private void handleNewSponsorBtn_Click(object sender, RoutedEventArgs e)
        {
            new SponsorRunner().Show();
            Close();
        }

        private void MenuDetailInfo_Click(object sender, RoutedEventArgs e)
        {
            new DetailedInfo().Show();
            Close();
        }

        private void NewViewer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NewRunner_Click(object sender, RoutedEventArgs e)
        {
            new EarlyOrNow().Show();
            Close();
        }
    }
}
