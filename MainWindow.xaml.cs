using Microsoft.Win32;
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

namespace VideoMAX.Practic
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        bool vol = true;

        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
        }
        void UpdateSliderPosition()
        {
            duration.Value = player.Position.TotalSeconds;
            duration.SelectionEnd = duration.Value;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateSliderPosition();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            player.Pause();
            timer.Stop();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            player.Play();
            timer.Start();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            player.Position = player.Position.Add(new TimeSpan(0, 0, 0, 15));
            UpdateSliderPosition();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (vol)
            {
                player.Volume = 0;
                vol = false;
            }
            else
            {
                player.Volume = 1;
                vol = true;
            }
        }

        private void player_MediaOpened(object sender, RoutedEventArgs e)
        {
            duration.Minimum = 0;
            duration.Maximum = player.NaturalDuration.TimeSpan.TotalSeconds;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            open.Filter = "Text Files(*.mp4)|*.mp4|All files (*.*)|*.*";
            open.FilterIndex = 0;
            open.CheckFileExists = true;
            if (open.ShowDialog() == true)
            {
                player.Source = new Uri(open.FileName);
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void volume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (player != null)
                player.Volume = volume.Value / 100;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            player.Position = player.Position.Add(new TimeSpan(0, 0, 0, -15));
            UpdateSliderPosition();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            player.SpeedRatio = 0.25;
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            player.SpeedRatio = 0.5;
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            player.SpeedRatio = 1;
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            player.SpeedRatio = 1.5;
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            player.SpeedRatio = 1.75;
        }
    }
}
