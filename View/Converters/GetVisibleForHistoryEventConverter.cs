using Avalonia.Data.Converters;
using Core.Models.AccesControl;
using Core.Models.Events;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace View.Converters
{
    public class GetVisibleForHistoryEventConverter : IMultiValueConverter
    {
        public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
        {            
            if (values == null || values.Count < 2) return false;
            if (values[0]==null || !(values[0] is EventHistoryItem historyItem)) return false;
            if (values[1] == null || !(values[1] is User user)) return false;
            return user.AccessLevel >= historyItem.AccessLevel;
        }
    }
}
