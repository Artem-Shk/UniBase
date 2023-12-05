
using UniBase.CORE.requests;
using UniBase.Models;

RequestResults requestResponse = new RequestResults();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRouting();
builder.Services.AddDbContext<DekanatModel>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}
app.UseStaticFiles();

app.MapControllers();
//app.UseRouting();
app.MapFallbackToFile("index.html");
app.UseHttpLogging();
app.Run();
