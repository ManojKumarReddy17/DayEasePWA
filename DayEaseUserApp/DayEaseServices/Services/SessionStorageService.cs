using Microsoft.JSInterop;

public class SessionStorageService
{
    private readonly IJSRuntime _js;

    public SessionStorageService(IJSRuntime js)
    {
        _js = js;
    }

    public async Task SetAsync<T>(string key, T value)
    {
        await _js.InvokeVoidAsync("sessionStore.set", key, value);
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        return await _js.InvokeAsync<T?>("sessionStore.get", key);
    }

    public async Task RemoveAsync(string key)
    {
        await _js.InvokeVoidAsync("sessionStore.remove", key);
    }

    public async Task ClearAsync()
    {
        await _js.InvokeVoidAsync("sessionStore.clear");
    }
}
