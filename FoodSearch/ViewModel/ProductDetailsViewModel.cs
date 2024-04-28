
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FoodSearch.Model;
using System.Diagnostics;

namespace FoodSearch.ViewModel;

[QueryProperty("Product", "Product")]
public partial class ProductDetailsViewModel : BaseViewModel
{
    [ObservableProperty]
    Product product;

    [RelayCommand]
    async Task OpenProductAsync(Product product)
    {
        if (product == null)
            return;
        try
        {
            Uri uri = new(product.Url);

            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
        catch(Exception ex)
        {
            Debug.WriteLine(ex.Message);
            await Shell.Current.DisplayAlert("Erreur", "Impossible d'ouvrir le navigateur", "OK");
        }
    }
}
