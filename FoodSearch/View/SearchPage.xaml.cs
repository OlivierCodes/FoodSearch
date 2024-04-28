using FoodSearch.ViewModel;

namespace FoodSearch.View;

public partial class SearchPage : ContentPage
{
	ProductsSearchViewModel viewModel;
	public SearchPage()
	{
		InitializeComponent();
		BindingContext = viewModel;
        this.viewModel = viewModel;



	}

	public async void OnSearch(object sender, EventArgs e)
	{
		viewModel.SearchProductsCommand.ExecuteAsync(searchBar.Text);

		searchBar.Text = string.Empty;

	}
}