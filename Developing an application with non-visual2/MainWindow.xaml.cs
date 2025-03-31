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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Developing_an_application_with_non_visual2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private TimeZoneInfo timeZone;
        public MainWindow()
        {
            InitializeComponent();

            timeZone = TimeZoneInfo.Local;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer;
            timer.Start();

            InitializeTimeZone();
        }
        private void InitializeTimeZone()
        {
            var timeZones = TimeZoneInfo.GetSystemTimeZones();
            TimeZone.ItemsSource = timeZones.Select(tz => tz.DisplayName);

            // Find the index of the local time zone
            int index = timeZones.ToList().FindIndex(tz => tz.Id == timeZone.Id);
            if (index != -1)
            {
                TimeZone.SelectedIndex = index;
            }

            TimeZone.SelectionChanged += TimeZone_Changed;
        }
        private void TimeZone_Changed(object sender, SelectionChangedEventArgs e)
        {
            var selectedTimeZoneName = (string)TimeZone.SelectedItem;
            var selectedTimeZone = TimeZoneInfo.GetSystemTimeZones().FirstOrDefault(tz => tz.DisplayName == selectedTimeZoneName);

            if (selectedTimeZone != null)
            {
                timeZone = selectedTimeZone;
                UpdateDisplay();
            }
        }

        private void Timer(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            DateTime utcTime = DateTime.UtcNow;
            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, timeZone);
            time.Text = localTime.ToString("HH:mm:ss");
        }
    }
}
