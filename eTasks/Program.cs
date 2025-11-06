using eTasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using eTasks.Shared.Extensions;
using System.ComponentModel;
using eTasks.Controller.Interfaces;
using eTasks.Controller;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.LoadServices(builder.HostEnvironment.BaseAddress);
builder.Services.LoadControllerServices();

await builder.Build().RunAsync();
