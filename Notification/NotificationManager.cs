using MaterialDesignThemes.Wpf;
using Notification.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Threading;

namespace Notification {
    public class NotificationManager {
        private readonly UIElement MainElement;
        private NotificationAdorner Adorner;

        public NotificationManager(UIElement mainElement, Enums.Type type, string message, NotificationSettings options) {
            MainElement = mainElement;
            if (options == null)
                options = new NotificationSettings();
            Adorner = new NotificationAdorner(mainElement, type, message, options);
        }
        public NotificationManager(UIElement mainElement, Enums.Type type, string message) {
            MainElement = mainElement;
            NotificationSettings options = new NotificationSettings();
            Adorner = new NotificationAdorner(mainElement, type, message, options);
        }

        public void ShowSuccess() {
            AdornerLayer.GetAdornerLayer(MainElement).Add(Adorner);
            Adorner.Visibility = Visibility.Visible;

            Adorner.customTooltip.StartTimer();
            Adorner.customTooltip.TimeOver += StopTimer;
        }

        public void StopTimer(object sender, bool e) {
            if (Adorner != null) {
                Adorner.Visibility = Visibility.Collapsed;
                Adorner = null;
            }
        }
    }
}
