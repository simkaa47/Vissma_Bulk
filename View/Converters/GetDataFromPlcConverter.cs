using Avalonia.Data.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace View.Converters
{
    public class GetDataFromPlcConverter : IMultiValueConverter
    {
        public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
        {
            if (values.Count != 6) return DateTime.MinValue;
            short temp = 0;
            var nums = values
                .Where(v => v!= null && short.TryParse(v.ToString(), out temp))
                .Select(v=>temp)
                .ToList();
            if(nums.Count!=6)return DateTime.MinValue;
            return new DateTime(nums[0] + 2000, nums[1], nums[2], nums[3], nums[4], nums[5]);
        }
    }
}
