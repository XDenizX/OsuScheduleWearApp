using OsuScheduleWearApp.ViewModels;

namespace OsuScheduleWearApp.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPageViewModel _viewModel;

	public SettingsPage()
	{
		InitializeComponent();

		_viewModel = BindingContext as SettingsPageViewModel;
	}

	private void Picker_SelectedIndexChanged(object sender, EventArgs e)
	{
		_viewModel.LoadCoursesCommand.Execute(this);
    }

	private void Picker_SelectedIndexChanged_1(object sender, EventArgs e)
	{
        _viewModel.LoadGroupsCommand.Execute(this);
    }

	private async void Picker_SelectedIndexChanged_2(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(new ShellNavigationState($"///schedule"));
    }
}