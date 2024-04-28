using FoodSearch.Services;
using FoodSearch.View;
using FoodSearch.ViewModel;
using Microsoft.Extensions.Logging;

namespace FoodSearch;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG

        builder.Services.AddSingleton<ProductService>();

        builder.Services.AddTransient<ProductViewModel>();
        builder.Services.AddTransient<MainPage>();

        builder.Services.AddTransient<ProductDetailsViewModel>();
        builder.Services.AddTransient<DetailsPage>();


        builder.Services.AddSingleton<ProductsSearchViewModel>();
        builder.Services.AddSingleton<SearchPage>();

#endif

        return builder.Build();
    }
}
