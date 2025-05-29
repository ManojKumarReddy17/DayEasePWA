using DayEaseServices.Services;
using DayEaseServices.Services.IServices;
using DayEaseUserApp;
using Domain.RequestModels;
using Domain.Utilities;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Registration.IApiService;
using System.Net.Http;
using Blazored.LocalStorage;

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
//builder.Services.AddScoped<RegistrationState>();
builder.Services.AddBlazoredLocalStorage();
// ✅ Use Blazored Session Storage for session-like behavior in Blazor WASM
//builder.Services.AddBlazoredSessionStorage();

await builder.Build().RunAsync();



//var builder = WebAssemblyHostBuilder.CreateDefault(args);
//builder.RootComponents.Add<App>("#app");
//builder.RootComponents.Add<HeadOutlet>("head::after");
//// Add configuration for ApiSettings
//builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));
////builder.Services.AddHttpClient<IRegistration, RegistrationService>();
////builder.Services.AddScoped<IRegistration, RegistrationService>();
//builder.Services.AddHttpClient<IRegistration, RegistrationService>(client =>
//{
//    client.BaseAddress = new Uri(builder.Configuration["ApiSettings:DayEase_API"]);
//});

//builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
////var config = builder.Configuration.GetSection("ApiSettings")["DayEase_API"];
////Console.WriteLine("API URL from config: " + config);

//// ? Register ApiService
//builder.Services.AddScoped<ApiService>();
//builder.Services.AddScoped<UserService>();


//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//await builder.Build().RunAsync();
