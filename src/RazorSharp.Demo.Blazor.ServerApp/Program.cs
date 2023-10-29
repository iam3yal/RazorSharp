using RazorSharp.Demo.Data.EntityFramework;
using RazorSharp.EntityFrameworkAdapter;

var builder = WebApplication.CreateBuilder(args);

builder.Logging
       .SetMinimumLevel(builder.Environment.IsDevelopment() ? LogLevel.Debug : LogLevel.Warning)
       .AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning);

builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddRazorSharpEntityFrameworkAdapter();
builder.Services.AddProductsDbContext();
builder.Services.AddHttpClient("ApiServer",
                               http => {
                                   http.BaseAddress = new Uri("https://localhost:7020");
                               });

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();