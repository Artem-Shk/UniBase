using System.Diagnostics;

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
app.Use(async (context, next) =>
{
    Debug.WriteLine($"1. Endpoint: {context.GetEndpoint()?.DisplayName ?? "(null)"}");
    await next(context);
});
app.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("Привет, мир!");
    });


app.UseRouting();
app.UseEndpoints(endpoints =>
{

    endpoints.MapControllers();
});

// Location 2: after routing runs, endpoint will be non-null if routing found a match.
app.Use(async (context, next) =>
{
    Debug.WriteLine($"2. Endpoint: {context.GetEndpoint()?.DisplayName ?? "(null)"}");
    await next(context);
});

// Location 3: runs when this endpoint matches
app.MapGet("/api", (HttpContext context) =>
{
    Debug.WriteLine($"3. Endpoint: {context.GetEndpoint()?.DisplayName ?? "(null)"}");
    return "Hello World!";
}).WithDisplayName("Hello");



// Location 4: runs after UseEndpoints - will only run if there was no match.
app.Use(async (context, next) =>
{
    Debug.WriteLine($"4. Endpoint: {context.GetEndpoint()?.DisplayName ?? "(null)"}");
    await next(context);
});
app.UseAuthentication();
app.UseAuthorization();

app.MapFallbackToFile("index.html");

app.Run();
