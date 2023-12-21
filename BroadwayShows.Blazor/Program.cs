using BroadwayShows.Blazor.Pages;
using BroadwayShows.Library.Data;
using BroadwayShows.Library.Services;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Calendars;
using static System.Net.Mime.MediaTypeNames;
using Auth0.AspNetCore.Authentication;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<BroadwayShowsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ShowsService>();
builder.Services.AddScoped<TheaterService>();
builder.Services.AddScoped<CastCrewService>();
builder.Services.AddScoped<TicketSalesService>();
builder.Services.AddScoped<TicketDataService>();
builder.Services.AddScoped<GenreService>();
builder.Services.AddScoped<WorkingPositionService>();
builder.Services.AddControllersWithViews();
builder.Services.AddSyncfusionBlazor();
builder.Services
    .AddAuth0WebAppAuthentication(options => {
        options.Domain = builder.Configuration["Auth0:Domain"];
        options.ClientId = builder.Configuration["Auth0:ClientId"];
    });






var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication(); // Ensure this is before UseAuthorization and after UseRouting
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.Run();
