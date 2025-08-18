using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Light.ValueConverters
{
    public class AvatarConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            const string avatarAssetPath = "../Assets/icons8-пользователь-96.png";
            string avatarPath = value as string;

            if (CanLoadFileWith(avatarPath))
            {
                return avatarPath;
            }
            
            return avatarAssetPath;
        }

        private bool CanLoadFileWith(string avatarPath)
        {
            return !string.IsNullOrWhiteSpace(avatarPath) && !string.IsNullOrEmpty(avatarPath) && File.Exists(avatarPath);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
