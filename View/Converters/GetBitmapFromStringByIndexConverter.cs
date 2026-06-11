using Avalonia.Platform;
using Avalonia;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Avalonia.Media.Imaging;

namespace View.Converters
{
    public class GetBitmapFromStringByIndexConverter:Converter
    {
        public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            int index = 0;
            if (value is null) return null;
            if (!(int.TryParse(value.ToString(), out index))) return null;            
            if (!(parameter is IEnumerable<string> list)) return null;
            if (list.Count() < index + 1) return null;
            string path =  list.ElementAt(index);

            Uri uri;

            // Allow for assembly overrides
            if (path.StartsWith("avares://"))
            {
                uri = new Uri(path);
            }
            else
            {
                string assemblyName = Assembly.GetEntryAssembly().GetName().Name;
                uri = new Uri($"avares://{assemblyName}/{path}");
            }

            //var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
            var asset = AssetLoader.Open(uri);

            return new Bitmap(asset);
        }
    }
}
