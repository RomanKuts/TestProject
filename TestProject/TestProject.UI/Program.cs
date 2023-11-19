using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TestProject.Services.Configurations;
using TestProject.UI;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.RegisterServices();

builder.Services.ConfigureRefit(builder.Configuration);

builder.Services.AddHttpContextAccessor();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

await builder.Build().RunAsync();