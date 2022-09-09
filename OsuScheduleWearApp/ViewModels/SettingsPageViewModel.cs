using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OrelStateUniversity.API;
using OrelStateUniversity.API.Models;

namespace OsuScheduleWearApp.ViewModels;

public partial class SettingsPageViewModel : ObservableObject
{
    private readonly ScheduleApiClient _client;

    [ObservableProperty]
    private IEnumerable<Division> _divisions;

    [ObservableProperty]
    private IEnumerable<Course> _courses;

    [ObservableProperty]
    private IEnumerable<Group> _groups;

    [ObservableProperty]
    private Division _selectedDivision;

    [ObservableProperty]
    private Course _selectedCourse;

    [ObservableProperty]
    private Group _selectedGroup;

    [RelayCommand]
    private async Task LoadDivisions()
    {
        Divisions = await _client.GetStudentDivisionsAsync();
    }

    [RelayCommand(CanExecute = nameof(CanLoadCourses))]
    private async Task LoadCourses()
    {
        Courses = Enumerable.Empty<Course>();

        if (SelectedDivision == null)
        {
            return;
        }

        Courses = await _client.GetCoursesAsync(SelectedDivision.Id);
    }

    private bool CanLoadCourses()
    {
        return Divisions.Any() && SelectedDivision != null;
    }

    [RelayCommand]
    private async Task LoadGroups()
    {
        Groups = Enumerable.Empty<Group>();

        if (SelectedDivision == null)
        {
            return;
        }

        if (SelectedCourse == null)
        {
            return;
        }

        Groups = await _client.GetGroupsAsync(SelectedDivision.Id, SelectedCourse.Number);
    }

    public SettingsPageViewModel(ScheduleApiClient client)
    {
        _client = client;

        LoadDivisionsCommand.Execute(this);
    }
}
