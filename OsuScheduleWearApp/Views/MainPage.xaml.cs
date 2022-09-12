using OsuScheduleWearApp.ViewModels;

namespace OsuScheduleWearApp.Views;

public partial class MainPage : ContentPage
{
	private readonly MainPageViewModel _viewModel;

	public MainPage()
	{
		InitializeComponent();

        _viewModel = BindingContext as MainPageViewModel;
    }
}