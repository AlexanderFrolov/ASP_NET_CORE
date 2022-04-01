using ASP_App.Middlewares;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.Environment.WebRootPath = "Views";

if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "Views"))
});

app.UseRouting();

// write logs into console and txt file
app.UseMiddleware<LoggingMidlleware>();

// route for root page
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync($"Welcome to the {app.Environment.ApplicationName}!");
    });
});

// other routing 
app.Map("/about", builder => About(builder, app.Environment));
app.Map("/config", builder => Config(builder, app.Environment));

// if route not found
app.Run(async context =>
{
    await context.Response.WriteAsync("Page not found!  Hello from non-Map delegate. <p>");
});

app.Run();

/// <summary>
///  Config page handler
/// </summary>
static void Config(IApplicationBuilder app, IWebHostEnvironment env)
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync($"App name: {env.ApplicationName}. App running configuration: {env.EnvironmentName}");
    });
}

/// <summary>
///  About page handler
/// </summary>
static void About(IApplicationBuilder app, IWebHostEnvironment env)
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync($"{env.ApplicationName} - ASP.Net Core tutorial project");
    });
}