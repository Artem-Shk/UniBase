
using Microsoft.AspNetCore.Mvc;
using System.Net.Security;
using UniBase.CORE.requests;
using UniBase.Models;

[assembly: ApiController]
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.MapFallbackToFile("index.html");

app.Run();
