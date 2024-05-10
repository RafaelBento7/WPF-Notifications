using Microsoft.Xaml.Behaviors.Layout;
using System;
using System.Collections;
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
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace Notification {
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window {

        public DispatcherTimer Timer;
        public int TimerSeconds = 5000;

        public void startTimer() {
            pbTimer.Maximum = TimerSeconds;
            pbTimer.Value = TimerSeconds;
            Timer = new DispatcherTimer();
            Timer.Tick += Timer_Tick;
            Timer.Interval = TimeSpan.FromMilliseconds(5);
            Timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e) {
            Dispatcher.Invoke(() => pbTimer.Value -= 5);

            if (pbTimer.Value <= 0) {
                Timer.Stop();
            }
        }

        public MainWindow() {
            InitializeComponent();
            this.ContentRendered += (s, e) => {
                //startTimer();
            };

        }


        private void ShowTooltip(UIElement targetElement) {
            Task.Run(() => {
                Dispatcher.Invoke(() => {
                    NotificationManager a = new NotificationManager(mainGrid);
                    a.ShowSuccess();
                });
            });

            //new stackpanelwindow().Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            UIElement targetElement = mainGrid;

            ShowTooltip(targetElement);
        }
    }
}
