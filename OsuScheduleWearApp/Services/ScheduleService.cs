using Microsoft.Extensions.Options;
using OrelStateUniversity.API;
using OrelStateUniversity.API.Models;
using OsuScheduleWearApp.Helpers;
using OsuScheduleWearApp.Settings;

namespace OsuScheduleWearApp.Services;

public class ScheduleService
{
    private readonly ScheduleApiClient _client = new();
    private Schedule _schedule;

    public delegate void ScheduleUpdatedHandler(Schedule updatedSchedule);
    public event ScheduleUpdatedHandler ScheduleUpdated;

    public ScheduleService(IOptions<PersonSettings> options)
    {
        
    }

    public Lesson GetActualLesson()
    {
        return _schedule.Lessons
            .GroupBy(lesson => lesson.Date)
            .Where(lessonGroup => DateTime.Parse(lessonGroup.Key) >= DateTime.Now.Date)
            .OrderBy(lessonsGroup => lessonsGroup.Key)
            .FirstOrDefault()
            .Where(lesson =>
                DateTime.Now.TimeOfDay < LessonTimeHelper.GetStartTime(lesson.Number) 
                + LessonTimeHelper.LessonDuration / 2)
            .OrderBy(lesson => lesson.Number)
            .FirstOrDefault();
    }

    public async Task UpdateScheduleAsync()
    {
        _schedule = await _client.GetScheduleAsync(8379);
        ScheduleUpdated?.Invoke(_schedule);
    }

    public void RequestUpdate()
    {
        ScheduleUpdated?.Invoke(_schedule);
    }
}
