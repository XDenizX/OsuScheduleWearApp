using OsuScheduleWearApp.ViewModels;

namespace OsuScheduleWearApp.Views;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageViewModel viewModel)
	{
		BindingContext = viewModel;

		InitializeComponent();
	}
}