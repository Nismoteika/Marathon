﻿using System;
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
    /// Логика взаимодействия для InteractiveMap.xaml
    /// </summary>
    public partial class InteractiveMap : Window
    {
        public InteractiveMap()
        {
            InitializeComponent();
        }

        private void HandleBtnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
