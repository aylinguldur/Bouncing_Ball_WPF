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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer_1 = new DispatcherTimer();
        DispatcherTimer timer_2 = new DispatcherTimer();
        DispatcherTimer timer_3 = new DispatcherTimer();
        DispatcherTimer timer_4 = new DispatcherTimer();
        int skor = 0;
        int speed = 15;
        int ball_speed = 10;
        double ball_X = 20;
        double ball_Y = 20;
        double dx = 0;
        double dy = 0;
        bool kesim_noktası = false;
        void Kesim_noktası()
        {
            if (ball_Y >= 250 && ball_Y <= 260 && ball_X > dx && ball_X < dy)
            {
                kesim_noktası = true;
                ++skor;
                sonuc.Text = skor.ToString();
            }
        }

        public MainWindow()
        {
            timer_1.Interval = TimeSpan.FromMilliseconds(50);
            timer_1.Tick += Timer_1_Tick;
            timer_2.Interval = TimeSpan.FromMilliseconds(50);
            timer_2.Tick += Timer_2_Tick;
            timer_3.Interval = TimeSpan.FromMilliseconds(50);
            timer_3.Tick += Timer_3_Tick;
            timer_4.Interval = TimeSpan.FromMilliseconds(50);
            timer_4.Tick += Timer_4_Tick;
        }
        private void buton_Click(object sender, RoutedEventArgs e)
        {
            timer_1.IsEnabled = true;
            timer_1.Start();

        } // buton görevi
        private void Timer_4_Tick(object sender, EventArgs e)
        {
            dx = Convert.ToDouble(Canvas.GetLeft(cubuk));
            dx = dx + 15;
            dy = dx + 125;
            ball_X = Convert.ToDouble(Canvas.GetLeft(ball));
            ball_Y = Convert.ToDouble(Canvas.GetTop(ball));
            Canvas.SetLeft(ball, ball_X - ball_speed);
            Canvas.SetTop(ball, ball_Y - ball_speed);
            if (ball_X <= 0)
            {
                timer_4.Stop();
                timer_3.Start();
            }
            else if (ball_Y <= 0)
            {
                timer_4.Stop();
                timer_2.Start();
            }
        }

        private void Timer_3_Tick(object sender, EventArgs e)
        {
            dx = Convert.ToDouble(Canvas.GetLeft(cubuk));
            dx = dx + 15;
            dy = dx + 125;
            ball_X = Convert.ToDouble(Canvas.GetLeft(ball));
            ball_Y = Convert.ToDouble(Canvas.GetTop(ball));
            Canvas.SetLeft(ball, ball_X + ball_speed);
            Canvas.SetTop(ball, ball_Y - ball_speed);
            if (ball_X + ball.Width >= 785)
            {
                timer_3.Stop();
                timer_4.IsEnabled = true;
                timer_4.Start();

            }
            else if (ball_Y <= 0)
            {
                timer_3.Stop();
                timer_1.Start();

            }
        }
        private void Timer_2_Tick(object sender, EventArgs e)
        {
            dx = Convert.ToDouble(Canvas.GetLeft(cubuk));
            dx = dx + 15;
            dy = dx + 125;
            ball_X = Convert.ToDouble(Canvas.GetLeft(ball));
            ball_Y = Convert.ToDouble(Canvas.GetTop(ball));
            Canvas.SetLeft(ball, ball_X - ball_speed);
            Canvas.SetTop(ball, ball_Y + ball_speed);
            Kesim_noktası();
            if (kesim_noktası == false)
            {
                if (ball_Y + ball.Height >= 300)
                {
                    timer_2.Stop();
                    MessageBox.Show("OYUN BİTTİİ! " + "    " + "SKOR : " + skor);


                }
                else if (ball_X <= 0)
                {
                    timer_2.Stop();
                    timer_1.Start();
                }
            }
            else if (kesim_noktası == true)
            {
                timer_2.Stop();
                timer_4.IsEnabled = true;
                timer_4.Start();
                kesim_noktası = false;
            }


        }
        private void Timer_1_Tick(object sender, EventArgs e)
        {
            dx = Convert.ToDouble(Canvas.GetLeft(cubuk));
            dx = dx + 15;
            dy = dx + 125;
            ball_X = Convert.ToDouble(Canvas.GetLeft(ball));
            ball_Y = Convert.ToDouble(Canvas.GetTop(ball));
            Canvas.SetLeft(ball, ball_X + ball_speed);
            Canvas.SetTop(ball, ball_Y + ball_speed);
            Kesim_noktası();
            if (kesim_noktası == false)
            {
                if (ball_X + ball.Width >= 785)
                {
                    timer_1.Stop();
                    timer_2.IsEnabled = true;
                    timer_2.Start();
                }
                else if (ball_Y + ball.Height >= 300)
                {
                    timer_1.Stop();
                    MessageBox.Show("OYUN BİTTİİ! " + "    "+ "SKOR : " + skor); 
                }
            }
            else if (kesim_noktası == true)
            {
                timer_1.Stop();
                timer_3.IsEnabled = true;
                timer_3.Start();
                kesim_noktası = false;

            }

        }
        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left && Canvas.GetLeft(cubuk) > 0)
            {
                Canvas.SetLeft(cubuk, Canvas.GetLeft(cubuk) - speed);
            }
            else if (e.Key == Key.Right && Canvas.GetLeft(cubuk) + cubuk.Height < 700)
            {
                Canvas.SetLeft(cubuk, Canvas.GetLeft(cubuk) + speed);
            }
        }
    }
}
