using Avalonia.Data.Converters;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;

namespace View.Converters
{
    public  class Converter : IValueConverter
    {    
        public virtual object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new Exception("Метод Convert не реализован");            
        }

        public virtual object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {

            return value;
        }
    }
}
