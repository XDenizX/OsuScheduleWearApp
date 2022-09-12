using OsuScheduleWearApp.Services;
using OsuScheduleWearApp.Views;

namespace OsuScheduleWearApp;

public partial class App : Application
{
	private readonly ScheduleService _scheduleService;

	public App()
	{
		InitializeComponent();

		_scheduleService = DependencyService.Get<ScheduleService>();
		MainPage = new AppShell();
    }

	protected override void OnResume()
	{
		base.OnResume();

		_scheduleService.RequestUpdate();
	}
}
