using CondoApp.Web;
using CondoApp.Web.Services.Contracts;
using CondoApp.Web.Services.OpenWeather;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7066/") });
builder.Services.AddScoped<IBuildingService, BuildingService>();
builder.Services.AddScoped<IFlatService, FlatService>();
builder.Services.AddScoped<IExpenseService, ExpenseService>();
builder.Services.AddScoped<IOpenWeatherService, OpenWeatherService>();

await builder.Build().RunAsync();
