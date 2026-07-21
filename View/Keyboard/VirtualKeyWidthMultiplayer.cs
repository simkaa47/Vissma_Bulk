using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace View.Keyboard
{
    public class VirtualKeyWidthMultiplayer : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            //if (value is null || parameter is null) return 0;
            //double v = 0;
            //double p = 0;
            //double.TryParse(value.ToString(), out v);
            //double.TryParse(value.ToString(), out p);            
            //return v * (p / 10.0);

            var v = double.Parse(value.ToString());
            var p = double.Parse(parameter.ToString());
            return v * (p / 10.0);
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
