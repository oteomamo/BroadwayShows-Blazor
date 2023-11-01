using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BroadwayShows.Library.Data;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using BroadwayShows.Library.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add the DbContext
builder.Services.AddDbContext<BroadwayShowsContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 21)),
        mysqlOptions => mysqlOptions.MigrationsAssembly("BroadwayShows.Library")
    ));

builder.Services.AddTransient<ShowsService>();
builder.Services.AddTransient<TheaterService>();
builder.Services.AddTransient<CastCrewService>();
builder.Services.AddTransient<TicketSalesService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}



// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
