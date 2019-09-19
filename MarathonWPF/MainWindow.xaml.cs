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
            DispatcherTimer timer1 = new DispatcherTimer();
            timer1.Tick += new EventHandler(TimerTick);
            timer1.Interval = new TimeSpan(0, 1, 0);
            timer1.Start();
            updateDate();
        }

        private void updateDate()
        {
            DateTime dateNow = DateTime.Now;
            DateTime dateM = new DateTime(2019, 10, 21);
            TimeSpan revDate = dateM.Subtract(dateNow);
            ReverseTimer.Content = revDate.Days + " дней " + revDate.Hours + " часов и " + revDate.Minutes + " минут до старта марафона!";
        }

        private void TimerTick(object sender, EventArgs e)
        {
            updateDate();
        }

        private void HandleBtnAuthWindowOpen_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new AuthWindow().ShowDialog();
            this.Show();
        }
    }
}
