using LightApplication.LightChatsRequests;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace Light.ValueConverters
{
    public class MiniatureBitmapConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            //var miniature = value as Miniature;

            //try
            //{
            //    var task = Task.Run<BitmapImage>(async () =>
            //    {
            //        using (var stream = new InMemoryRandomAccessStream())
            //        {

            //            await stream.WriteAsync(miniature.Data.AsBuffer());
            //            stream.Seek(0);

            //            var bitmap = new BitmapImage();
            //            await bitmap.SetSourceAsync(stream);

            //            return bitmap;
            //        }

            //    });

            //    return task.Result; // Таймаут
            //}
            //catch
            //{
                return null;
            //}
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
