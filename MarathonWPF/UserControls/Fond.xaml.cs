using System.IO;
using System.Windows.Controls;
using System.Windows.Media;

namespace MarathonWPF
{
    /// <summary>
    /// Interaction logic for Fond.xaml
    /// </summary>
    public partial class Fond : UserControl
    {
        public Fond(string nameFond, string descFond, string image)
        {
            InitializeComponent();

            string path = @"..\..\res\";

            this.nameFond.Text = nameFond;

            if (descFond.Length > 200)
                this.descFond.Text = descFond.Substring(0, 197) + "...";
            else
                this.descFond.Text = descFond;

            try
            {
                this.imgFond.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(File.ReadAllBytes(path + image));
            }
            catch { }
        }
    }
}
