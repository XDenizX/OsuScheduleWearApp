using OsuScheduleWearApp.Helpers;
using System.Globalization;

namespace OsuScheduleWearApp.Converters;

internal class LessonNumberToTimeConverter : IValueConverter
{

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not int)
        {
            throw new ArgumentException(nameof(value));
        }

        var lessonNumber = (int) value;

        TimeSpan startTime = LessonTimeHelper.GetStartTime(lessonNumber);
        TimeSpan endTime = LessonTimeHelper.GetEndTime(lessonNumber);

        return $"{startTime:hh\\:mm} - {endTime:hh\\:mm}";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
