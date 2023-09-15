using Avalonia.Media;
using Core.Models.Events;
using System;
using System.Globalization;

namespace View.Converters
{
    internal class GetColorForHistoryEventConverter : Converter
    {
        public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is null) return null;
            if(!(value is EventHistoryItem eventHistory)) return null;
            if (eventHistory.EventType == EventType.Event) return Brush.Parse("#FFDCDCDC");
            return eventHistory.IsActive ? Brush.Parse("#FFFF0000") : Brush.Parse("#FF00FF00");
        }
    }
}
