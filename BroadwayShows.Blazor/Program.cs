using BroadwayShows.Blazor.Pages;
using BroadwayShows.Library.Data;
using BroadwayShows.Library.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<BroadwayShowsContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 21)),
        mysqlOptions => mysqlOptions.MigrationsAssembly("BroadwayShows.Library")
    ));

builder.Services.AddScoped<ShowsService>();
builder.Services.AddScoped<TheaterService>();
builder.Services.AddScoped<CastCrewService>();
builder.Services.AddScoped<TicketSalesService>();
builder.Services.AddScoped<TicketDataService>();

builder.Services.AddControllersWithViews();






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
