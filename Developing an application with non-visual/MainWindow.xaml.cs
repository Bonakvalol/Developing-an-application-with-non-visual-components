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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Developing_an_application_with_non_visual
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();

            timer.Interval = TimeSpan.FromSeconds(1);

            timer.Tick += Timer_Tick;

            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {

            DateTime currentTime = DateTime.Now;

            lblTime.Content = currentTime.ToString("HH:mm:ss");
        }
    }
}
