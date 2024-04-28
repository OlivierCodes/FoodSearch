
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FoodSearch.Model;
using FoodSearch.Services;
using FoodSearch.View;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace FoodSearch.ViewModel;

[QueryProperty("SearchTerm", "SearchTerm")]
public partial class ProductViewModel : BaseViewModel
{

    ProductService productService;
    public ObservableCollection<Product> Products { get; } = new();

    public ObservableCollection<Product> SearchedProducts { get; } = new();    
    public bool FirstRun { get; set; } = true;

    [ObservableProperty]
    bool isRefreshing;

    [ObservableProperty]
    string searchTerm;

    [ObservableProperty]
    string searchedTitle;
    
    public ProductViewModel(ProductService productService) 
    {
        Title = "Produits";
        this.productService = productService;
    
    }

    [RelayCommand]
    async Task GetRandomProductsAsync()
    {
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;

            var products = await productService.GetRandomProductsAsync();

            Products.Clear();

            foreach (var product in products)
                Products.Add(product);  


        }catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Erreur", "Impossible de récupérer la liste des produits ", "ok");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }
    }


    [RelayCommand]
    async Task SearchProductsAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            SearchedTitle = searchTerm;
            Title = SearchedTitle;

            SearchedProducts.Clear();

            var products = await productService.SearchProductAsync(SearchTerm);

            foreach (var product in products)
                SearchedProducts.Add(product);

            SearchTerm = null;

        }
        catch(Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Erreur", "Impossible de rechercher des produits ", "ok");
        }
        finally
        {
            IsBusy = false;
        }
    }



    [RelayCommand]
    async Task GoToDetailsAsync(Product product)
    {
        if (product is null) return;

        await Shell.Current.GoToAsync(nameof(DetailsPage), true, new Dictionary<string, object>
        {
            {"Product", product }
        });
    }

}
    

