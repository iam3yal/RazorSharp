using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using RazorSharp.Demo.Data.EntityFramework;
using RazorSharp.Demo.UI;
using RazorSharp.EntityFrameworkAdapter;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Logging
       .SetMinimumLevel(builder.HostEnvironment.IsDevelopment() ? LogLevel.Debug : LogLevel.Warning)
       .AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddRazorSharpEntityFrameworkAdapter();
builder.Services.AddProductsDbContext();
builder.Services.AddHttpClient("ApiServer",
                               http => {
                                   http.BaseAddress = new Uri("https://localhost:7020");
                               });

await builder.Build().RunAsync();