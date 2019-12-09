using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace MarathonWPF
{
    class RevTimer
    {
        private void updateDate()
        {
            DateTime dateNow = DateTime.Now;
            DateTime dateM = new DateTime(2020, 04, 01);
            TimeSpan revDate = dateM.Subtract(dateNow);
            label.Content = revDate.Days + " дней " + revDate.Hours + " часов и " + revDate.Minutes + " минут до старта марафона!";
        }

        private Label label;

        public RevTimer(Label lbl)
        {
            label = lbl;
            DispatcherTimer timer1 = new DispatcherTimer();
            timer1.Tick += new EventHandler(TimerTick);
            timer1.Interval = new TimeSpan(0, 1, 0);
            timer1.Start();
            updateDate();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            updateDate();
        }

        //ReverseTimer.Content = revDate.Days + " дней " + revDate.Hours + " часов и " + revDate.Minutes + " минут до старта марафона!";

    }
}
