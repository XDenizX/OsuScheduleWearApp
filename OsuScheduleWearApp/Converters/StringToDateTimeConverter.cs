using System.Globalization;

namespace OsuScheduleWearApp.Converters;

internal class StringToDateTimeConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not string)
        {
            throw new ArgumentException(nameof(value));
        }

        var dateText = value as string;

        return DateTime.Parse(dateText);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
