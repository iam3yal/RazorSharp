using System.Text;

using Microsoft.Extensions.DependencyInjection.Extensions;

using RazorSharp.Demo.Data.Abstractions.Services;
using RazorSharp.Demo.Data.Models;
using RazorSharp.Demo.Search.DataServer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(o => o.AddDefaultPolicy(p =>
                                                     p.WithOrigins("https://localhost:7030",
                                                                   "https://localhost:7040")
                                                      .WithHeaders("*")
                                                      .WithMethods("*")));

builder.Services.Add(new ServiceDescriptorAggregator()
                     .Singleton<IDataLoader>(new PeopleDataHandler())
                     .Singleton<IDataProvider<IReadOnlyDictionary<Person, StringBuilder>>>());

builder.Services.AddHostedService<PeopleDataService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();