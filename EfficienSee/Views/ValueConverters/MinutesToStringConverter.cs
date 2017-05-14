using System;
using System.Globalization;
using Xamarin.Forms;

namespace EfficienSee.Views.ValueConverters
{
    public class MinutesToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double minutes;
            string display = string.Empty;

            if (!double.TryParse(value.ToString(), out minutes))
            {
                display = "???";
            }
            else
            {
                display = $"{minutes:n} minutes";
            }

            return display;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
