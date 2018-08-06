using System;
using System.Globalization;
using Xamarin.Forms;

namespace TravelRecordApp.ViewModal.Converters
{
    public class DateTimeToStringConverter : IValueConverter
    {
        public DateTimeToStringConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string timeAgo = string.Empty;

            DateTimeOffset dateTime = (DateTimeOffset)value;
            DateTimeOffset rightNow = DateTimeOffset.Now;
            var diff = rightNow - dateTime;

            if (diff.TotalDays > 1)
            {
                return $"{dateTime:d}";
            }
            else
            {
                if (diff.TotalSeconds < 60)
                    return $"{diff.TotalSeconds} seconds ago";
                if (diff.TotalMinutes < 60)
                    return $"{diff.TotalMinutes} minutes ago";
                if (diff.TotalHours < 24)
                    return $"{diff.TotalHours} hours ago";
            }
            return timeAgo;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DateTimeOffset.Now;
        }
    }
}
