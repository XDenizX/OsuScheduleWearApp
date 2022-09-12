using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OrelStateUniversity.API.Models;
using OsuScheduleWearApp.Services;

namespace OsuScheduleWearApp.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    private readonly ScheduleService _scheduleService;

    [ObservableProperty]
    private Lesson _lesson;

    [RelayCommand]
    async Task UpdateSchedule() => await _scheduleService.UpdateScheduleAsync();

    public MainPageViewModel()
    {
        _scheduleService = DependencyService.Get<ScheduleService>();
        _scheduleService.ScheduleUpdated += OnScheduleChanged;

        UpdateScheduleCommand.Execute(this);
    }

    private void OnScheduleChanged(Schedule value)
    {
        Lesson = _scheduleService.GetActualLesson();
    }
}
