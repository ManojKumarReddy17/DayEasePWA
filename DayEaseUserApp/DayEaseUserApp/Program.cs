using Blazored.LocalStorage;
using DayEaseServices.Services;
using DayEaseServices.Services.IServices;
using DayEaseUserApp;
using Domain.RequestModels;
using Domain.Utilities;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Registration.IApiService;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.Configuration["ApiSettings:DayEase_API"])
});

builder.Services.AddScoped<IApiService, ApiService>();
builder.Services.AddScoped<IRegistration, RegistrationService>();
builder.Services.AddScoped<IUserLoginService, UserLoginService>();
builder.Services.AddScoped<IOrderService, OrderServices>();
builder.Services.AddScoped<CartState>();
builder.Services.AddScoped<IProductCategory, ProductCategoryService>();
builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<UserLocationState>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IUserLocationService, UserLocationService>();
builder.Services.AddScoped<GuestUserService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

//builder.Services.AddScoped<RegistrationState>();
builder.Services.AddBlazoredLocalStorage();
// ✅ Use Blazored Session Storage for session-like behavior in Blazor WASM
//builder.Services.AddBlazoredSessionStorage();

await builder.Build().RunAsync();




