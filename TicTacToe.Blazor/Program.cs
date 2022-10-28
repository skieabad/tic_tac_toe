using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TicTacToe.Blazor;
using TicTacToe.Business.Interface;
using TicTacToe.Business;
using MudBlazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<IGame, Game>();
builder.Services.AddSingleton<IMudPopoverService, MudPopoverService>();
builder.Services.AddSingleton<IDialogService, DialogService>();

await builder.Build().RunAsync();
