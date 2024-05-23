using foodApp.Models;
using Microsoft.JSInterop;
using System.Text.Json;

public class FavoriteProducts
{
    private const string LocalStorageKey = "favoriteProducts";
    private readonly IJSRuntime _jsRuntime;

    public FavoriteProducts(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task AddProductAsync(PrevViewedModel product)
    {
        var products = await GetFavoriteProductsAsync();
        products.RemoveAll(p => p.Id == product.Id);
        products.Insert(0, product);

        if (products.Count > 20)
        {
            products.RemoveAt(products.Count - 1);
        }

        var json = JsonSerializer.Serialize(products);
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", LocalStorageKey, json);
    }

    public async Task<List<PrevViewedModel>?> GetFavoriteProductsAsync()
    {
        var json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", LocalStorageKey);

        return string.IsNullOrEmpty(json) ? new List<PrevViewedModel>() : JsonSerializer.Deserialize<List<PrevViewedModel>>(json);
    }

    public async Task RemoveProductAsync(int productId)
    {
        var products = await GetFavoriteProductsAsync();
        products.RemoveAll(p => p.Id == productId);
        var json = JsonSerializer.Serialize(products);
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", LocalStorageKey, json);
    }
}
