global using BlazorECommerce.Shared;
global using Microsoft.AspNetCore.Components.Authorization;
using BlazorECommerce.Client;
using BlazorECommerce.Client.Services.AuthService;
using BlazorECommerce.Client.Services.CartService;
using BlazorECommerce.Client.Services.CategoryService;
using BlazorECommerce.Client.Services.CompanyService;
using BlazorECommerce.Client.Services.OrderService;
using BlazorECommerce.Client.Services.ProductService;
using BlazorECommerce.Client.Services.ThemeService;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();


builder.Services.AddMudServices();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IThemeService, ThemeService>();

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

await builder.Build().RunAsync();
