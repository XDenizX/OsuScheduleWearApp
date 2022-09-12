using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using OrelStateUniversity.API;
using OsuScheduleWearApp.Services;

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

		var client = new ScheduleApiClient();

        DependencyService.RegisterSingleton(client);
        DependencyService.RegisterSingleton(new ScheduleService(client));

        return builder.Build();
	}
}
