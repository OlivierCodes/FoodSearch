using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FoodSearch.View;
using System.Collections.ObjectModel;

namespace FoodSearch.ViewModel;

partial class ProductsSearchViewModel : BaseViewModel
{
    public ObservableCollection<String> SearchtermsHistory { get; set; } = new();

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(isSearchTermsHistoryNotEmpty))]
    bool isSearchtermsHistoryEmpty = true;

    bool isSearchTermsHistoryNotEmpty => !isSearchtermsHistoryEmpty;


    public ProductsSearchViewModel()
    {

        Title = "Rechercher";
    }

    [RelayCommand]
    async Task SearchProductsAsync(string searchTerm)
    {
        SearchtermsHistory.Add(searchTerm);

        isSearchtermsHistoryEmpty = false;

        await Shell.Current.GoToAsync(nameof(MainPage), true, new Dictionary<string, object>
        {
            { "SearchTerm", searchTerm }
        });
    }

}
