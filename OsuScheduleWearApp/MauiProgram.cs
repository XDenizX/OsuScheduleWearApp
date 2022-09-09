using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using OrelStateUniversity.API;
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
			.UseMauiCommunityToolkitCore()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services
			.AddOptions()
			.AddSingleton<MainPage>()
			.AddSingleton<SettingsPage>()
			.AddTransient<SettingsPageViewModel>()
			.AddTransient<MainPageViewModel>()
			.AddSingleton<ScheduleApiClient>()
			.AddSingleton<ScheduleService>();


        return builder.Build();
	}
}
