using OsuScheduleWearApp.ViewModels;

namespace OsuScheduleWearApp.Views;

public partial class SettingsPage : ContentPage
{
	private readonly SettingsPageViewModel _viewModel;
	public SettingsPage(SettingsPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = _viewModel = viewModel;
	}

	private void Picker_SelectedIndexChanged(object sender, EventArgs e)
	{
		_viewModel.LoadCoursesCommand.Execute(this);
    }

	private void Picker_SelectedIndexChanged_1(object sender, EventArgs e)
	{
        _viewModel.LoadGroupsCommand.Execute(this);
    }
}