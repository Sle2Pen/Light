using System;
using Windows.UI.Xaml.Data;

namespace Light.ValueConverters
{
    public class MessageTimeConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int unixTime = (int)value;

            if (unixTime != 0)
            {
                var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                var dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(unixTime);

                if (now-unixTime< 82800)//вот тут варьировать сколько нада
                {
                    return dateTimeOffset
                        .UtcDateTime
                        .ToLocalTime()
                        .ToString("HH:mm");
                }

                if (now - unixTime < 518400)
                {
                    return dateTimeOffset
                        .UtcDateTime
                        .ToLocalTime()
                        .DayOfWeek
                        .ToString();
                }

                return dateTimeOffset
                        .UtcDateTime
                        .ToLocalTime()
                        .ToString("dd.MM.yyyy");
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
