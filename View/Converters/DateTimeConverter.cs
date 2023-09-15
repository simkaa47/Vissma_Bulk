using System;
using System.Globalization;

namespace View.Converters
{
    public  class DateTimeConverter:Converter
    {
        public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is null || value is not DateTime dt || dt == DateTime.MinValue) return "Информация недоступна";
            return value.ToString();

        }
    }
}
