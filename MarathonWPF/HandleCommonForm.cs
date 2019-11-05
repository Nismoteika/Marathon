using System.Windows;
using System.Windows.Controls;

namespace MarathonWPF
{
    class HandleBack
    {
        Window owner;
        Button back;

        public HandleBack(Window owner, Button back)
        {
            this.back = back;
            this.owner = owner;
            back.Click += Back_Click;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            owner.Close();
        }
    }
}
