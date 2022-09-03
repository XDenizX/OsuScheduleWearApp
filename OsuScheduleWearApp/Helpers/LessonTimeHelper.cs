namespace OsuScheduleWearApp.Helpers;

internal static class LessonTimeHelper
{
    public const int LessonDirationMinutes = 90;
    public static readonly TimeSpan LessonDuration = new(0, 90, 0);

    private static readonly Dictionary<int, TimeSpan> _lessonStartTimes = new()
    {
        {1, new TimeSpan(08, 30, 00)},
        {2, new TimeSpan(10, 10, 00)},
        {3, new TimeSpan(12, 00, 00)},
        {4, new TimeSpan(13, 40, 00)},
        {5, new TimeSpan(15, 20, 00)},
        {6, new TimeSpan(17, 00, 00)},
        {7, new TimeSpan(18, 40, 00)},
        {8, new TimeSpan(20, 15, 00)}
    };

    public static TimeSpan GetStartTime(int lessonNumber)
    {
        if (!_lessonStartTimes.ContainsKey(lessonNumber))
        {
            throw new ArgumentOutOfRangeException(nameof(lessonNumber));
        }

        return _lessonStartTimes[lessonNumber];
    }

    public static TimeSpan GetEndTime(int lessonNumber)
    {
        return GetStartTime(lessonNumber) + TimeSpan.FromMinutes(LessonDirationMinutes);
    }
}
