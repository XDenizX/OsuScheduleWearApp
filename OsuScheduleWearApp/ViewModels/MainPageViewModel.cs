using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OrelStateUniversity.API;
using OrelStateUniversity.API.Models;

namespace OsuScheduleWearApp.ViewModels;

partial class MainPageViewModel : ObservableObject
{
    [ObservableProperty]
    private Schedule _schedule;

    partial void OnScheduleChanged(Schedule value)
    {
        Lesson = GetActualLesson(value);
    }

    [ObservableProperty]
    private Lesson _lesson;

    [ObservableProperty]
    private AsyncRelayCommand _updateScheduleCommand;

    private readonly ScheduleApiClient _client;

    public MainPageViewModel()
    {
        _client = new ScheduleApiClient();

        UpdateScheduleCommand = new AsyncRelayCommand(UpdateScheduleAsync);
        UpdateScheduleCommand.Execute(this);
    }

    private Lesson GetActualLesson(Schedule schedule)
    {
        return schedule.Lessons
            .GroupBy(lesson => lesson.Date)
            .OrderBy(lessonsGroup => lessonsGroup.Key)
            .FirstOrDefault()
            .OrderBy(lesson => lesson.Number)
            .FirstOrDefault();
    }

    private async Task UpdateScheduleAsync()
    {
        Schedule = await _client.GetScheduleAsync(8379);
    }
}
