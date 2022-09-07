using CommunityToolkit.Maui;
using OsuScheduleWearApp.Services;
using OsuScheduleWearApp.ViewModels;
using OsuScheduleWearApp.Views;

namespace OsuScheduleWearApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services
			.AddOptions()
			.AddSingleton<MainPage>()
			.AddTransient<MainPageViewModel>()
			.AddSingleton<ScheduleService>();

		return builder.Build();
	}
}
