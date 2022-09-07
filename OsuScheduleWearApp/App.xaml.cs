using OsuScheduleWearApp.Services;
using OsuScheduleWearApp.Views;

namespace OsuScheduleWearApp;

public partial class App : Application
{
	private readonly ScheduleService _scheduleService;

	public App(MainPage mainPage, ScheduleService scheduleService)
	{
		InitializeComponent();

		_scheduleService = scheduleService;
		MainPage = mainPage;
	}

	protected override void OnResume()
	{
		base.OnResume();

		_scheduleService.RequestUpdate();
	}
}
