using CommunityToolkit.Mvvm.Input;
using FoodSearch.Model;
using FoodSearch.ViewModel;

namespace FoodSearch.View;

public partial class MainPage : ContentPage
{
    ProductViewModel viewModel;

    public MainPage(ProductViewModel viewModel)
    {
        InitializeComponent();

        this.viewModel = viewModel;

        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        productCollection.ItemsSource = viewModel.Products;
        
        if (viewModel.FirstRun = true  && viewModel.GetRandomProductsCommand.CanExecute(null))
        {
            await viewModel.GetRandomProductsCommand.ExecuteAsync(null);
            viewModel.FirstRun = false;
        }

        base.OnAppearing();

    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        if(!string.IsNullOrEmpty(viewModel.SearchTerm))
        {
            await viewModel.SearchProductsCommand.ExecuteAsync(null);
        }

        if (Parent is ShellSection && ((ShellSection)Parent).Route == nameof(SearchPage) )
        {
            viewModel.Title = viewModel.SearchedTitle;
            productCollection.ItemsSource = viewModel.SearchedProducts;
        }
        else
        {
            viewModel.Title = "Produits";
            productCollection.ItemsSource = viewModel.Products;
        }
        base.OnNavigatedTo(args);
    }


}
