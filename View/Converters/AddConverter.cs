using System;
using System.Globalization;

namespace View.Converters
{
    public class AddConverter:Converter
    {
        public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is null) return null;
            if(!float.TryParse(value.ToString(), out float a))return value;
            if (parameter is null) return value;
            if (!float.TryParse(parameter.ToString(), out float b)) return value;
            return (a+b).ToString();


        }
    }
}
