using Microsoft.Extensions.Options;
using OrelStateUniversity.API;
using OrelStateUniversity.API.Models;
using OsuScheduleWearApp.Helpers;
using OsuScheduleWearApp.Services;
using OsuScheduleWearApp.Settings;

[assembly: Dependency(typeof(ScheduleService))]
namespace OsuScheduleWearApp.Services;

public class ScheduleService
{
    private readonly ScheduleApiClient _client;
    private Schedule _schedule;

    public delegate void ScheduleUpdatedHandler(Schedule updatedSchedule);
    public event ScheduleUpdatedHandler ScheduleUpdated;

    public ScheduleService(ScheduleApiClient client)
    {
        _client = client;
    }

    public Lesson GetActualLesson()
    {
        return _schedule.Lessons
            .OrderBy(lesson => 
                DateTime.Parse(lesson.Date) 
                + LessonTimeHelper.GetStartTime(lesson.Number))
            .Where(lesson =>
                DateTime.Now < DateTime.Parse(lesson.Date)
                + LessonTimeHelper.GetStartTime(lesson.Number)
                + LessonTimeHelper.LessonDuration / 2)
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
