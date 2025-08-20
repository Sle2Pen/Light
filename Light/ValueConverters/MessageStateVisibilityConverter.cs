using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Light.ValueConverters
{
    public class MessageStateVisibilityConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var isOutgoing = (bool)value;

            if (isOutgoing)
            {
                return Visibility.Visible;
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
