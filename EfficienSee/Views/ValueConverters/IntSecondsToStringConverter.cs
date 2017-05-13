using System;
using System.Globalization;
using Xamarin.Forms;

namespace EfficienSee.Views.ValueConverters
{
    public class IntSecondsToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int seconds;
            string display = string.Empty;

            if (!Int32.TryParse(value.ToString(), out seconds))
            {
                display = "???";
            }
            else
            {
                display = $"{seconds:n} seconds";
            }

            return display;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
