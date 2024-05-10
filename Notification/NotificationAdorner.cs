using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using Notification.Enums;

namespace Notification {
    public class NotificationAdorner : Adorner {
        public readonly NotificationUserControl customTooltip;

        public NotificationAdorner(UIElement adornedElement, Enums.Type type, string message, NotificationSettings options) : base(adornedElement) {
            customTooltip = new NotificationUserControl(type, message, options);
            AddVisualChild(customTooltip);
            AddLogicalChild(customTooltip);
        }

        protected override Size MeasureOverride(Size constraint) {
            customTooltip.Measure(constraint);
            return customTooltip.DesiredSize;
        }

        protected override Size ArrangeOverride(Size finalSize) {
            double containerWidth = (AdornedElement as FrameworkElement)?.ActualWidth ?? 0;
            double containerHeight = (AdornedElement as FrameworkElement)?.ActualHeight ?? 0;

            // Put it in the right corner
            customTooltip.Arrange(new Rect(new Point(containerWidth - finalSize.Width, 0), finalSize));
            return new Size(containerWidth, containerHeight);
        }

        protected override Visual GetVisualChild(int index) {
            return customTooltip;
        }

        protected override int VisualChildrenCount => 1;
    }
}
