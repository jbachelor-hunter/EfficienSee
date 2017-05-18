using System;
using System.Globalization;
using Xamarin.Forms;

namespace EfficienSee.Views.ValueConverters
{
	public class TimeSpanToStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			TimeSpan time;
			string display = string.Empty;

			if (value is TimeSpan == false)
			{
				display = "???";
			}
			else
			{
				time = (TimeSpan)value;
				display = $"{time.Days} days {time.Hours} hours and {time.Minutes} minutes";
			}

			return display;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
