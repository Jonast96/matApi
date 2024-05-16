using Microsoft.JSInterop;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

public class ProductHistoryService
{
    private const string LocalStorageKey = "lastViewedProducts";
    private readonly IJSRuntime _jsRuntime;

    public ProductHistoryService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task AddProductAsync(PrevViewedModel product)
    {
        var products = await GetLastViewedProductsAsync();
        products.RemoveAll(p => p.Id == product.Id);
        products.Insert(0, product);

        if (products.Count > 10)
        {
            products.RemoveAt(products.Count - 1);
        }

        var json = JsonSerializer.Serialize(products);
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", LocalStorageKey, json);
    }

    public async Task<List<PrevViewedModel>> GetLastViewedProductsAsync()
    {
        var json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", LocalStorageKey);
        return string.IsNullOrEmpty(json) ? new List<PrevViewedModel>() : JsonSerializer.Deserialize<List<PrevViewedModel>>(json);
    }
}
