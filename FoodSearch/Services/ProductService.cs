using FoodSearch.Model;
using System.Net.Http.Json;

namespace FoodSearch.Services;
public class ProductService
{

    const string BASE_SEARCH_URL = "https://fr.openfoodfacts.org/cgi/search.pl?action=process&json=true";
    HttpClient client;

    public ProductService()
    {
        client = new HttpClient();
    }

    public async Task<List<Product>> GetRandomProductsAsync()
    {
        var page = new Random().Next(1, 1000);
        var url = $"{BASE_SEARCH_URL}&page={page}&page_size=10";
        var response = await client.GetAsync(url);
        var products = await GetProductsAsync(response);    
        return products;
   
    
    }

    public async Task<List<Product>> SearchProductAsync(string searchTerm)
    {
        var url = $"{BASE_SEARCH_URL}&tag_contains_0=contains&tagtype_0=categories" +
            $"&tag_0={searchTerm}&tagtype_1=label&page_size=10";

        var response =await client.GetAsync(url);

        var products = await GetProductsAsync(response);
        return products;
    }

    private async Task<List<Product>> GetProductsAsync(HttpResponseMessage response)
    {
        List<Product> products = new();

        if (response.IsSuccessStatusCode)
        {

            products = (await response.Content.ReadFromJsonAsync<ProductResult>()).Products;
        }

        return products;

    }
}
