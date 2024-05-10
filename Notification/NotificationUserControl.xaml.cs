using Notification.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
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

namespace Notification {
    /// <summary>
    /// Interação lógica para NotificationUserControl.xam
    /// </summary>
    public partial class NotificationUserControl : UserControl, INotificationEvent {

        /// <summary>
        /// Timer to the notifications
        /// </summary>
        public DispatcherTimer Timer;

        /// <summary>
        /// Settings of the timer
        /// </summary>
        public NotificationSettings Settings;

        /// <summary>
        /// Handler that triggers when the timer stops
        /// </summary>
        public EventHandler<bool> TimeOver;


        public NotificationUserControl(Enums.Type type, string message, NotificationSettings settings) {
            InitializeComponent();
            Settings = settings ?? new NotificationSettings();
        }

        public void StartTimer() {
            pbTimer.Maximum = Settings.Timer;
            pbTimer.Value = Settings.Timer;
            Timer = new DispatcherTimer();
            Timer.Tick += Timer_Tick;
            Timer.Interval = TimeSpan.FromMilliseconds(10);
            Timer.Start();
        }

        public void StopTimer() {
            Timer.Stop();
            TimeOver?.Invoke(this, true);
        }

        private void Timer_Tick(object sender, EventArgs e) {
            Dispatcher.Invoke(() => {
                pbTimer.Value -= 10;
                if (pbTimer.Value <= 0) {
                    StopTimer();
                }
            });
        }
    }
}
