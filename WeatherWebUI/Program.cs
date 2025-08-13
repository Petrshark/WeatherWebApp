using Microsoft.EntityFrameworkCore;
using WeatherWebUI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Naètení konfigurace
var configuration = builder.Configuration;
string? weatherApiUrl = configuration.GetSection("WeatherApi:Url").Value;

// Použití pøipojovacího øetìzce z hostingu
string? connectionString = configuration.GetConnectionString("MonsterDBConnection");

// Registrace služeb pro Dependency Injection
builder.Services.AddTransient<WeatherService>(provider => new WeatherService(weatherApiUrl!));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Registrace služby pro manuální stahování
builder.Services.AddSingleton<ManualDownloadService>();

// Registrace Worker služby
builder.Services.AddHostedService<Worker>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();