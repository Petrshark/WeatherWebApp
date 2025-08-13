using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly WeatherService _weatherService;
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly ManualDownloadService _manualDownloadService;

    public Worker(ILogger<Worker> logger, WeatherService weatherService, IServiceScopeFactory serviceScopeFactory, ManualDownloadService manualDownloadService)
    {
        _logger = logger;
        _weatherService = weatherService;
        _serviceScopeFactory = serviceScopeFactory;
        _manualDownloadService = manualDownloadService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            
            await PerformDownloadTask(stoppingToken);

            var delayTask = Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            var signalTask = _manualDownloadService.WaitForDownloadSignal(stoppingToken);

            await Task.WhenAny(delayTask, signalTask);
        }
    }

    private async Task PerformDownloadTask(CancellationToken stoppingToken)
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            _logger.LogInformation("Spouštím úlohu stahování dat...");

            string xmlData = await _weatherService.GetWeatherDataAsync();

            bool isStationOnline = xmlData != null;
            string? jsonData = null;

            if (isStationOnline)
            {
                _logger.LogInformation("Úspěšně staženo XML.");
                jsonData = _weatherService.ParseXmlToJson(xmlData);
                if (jsonData != null)
                {
                    _logger.LogInformation("Úspěšně převedeno na JSON.");
                }
            }
            else
            {
                _logger.LogWarning("Meteostanice nebyla dostupná.");
            }

            var record = new WeatherDataRecord
            {
                DownloadTimestamp = DateTime.Now,
                IsStationOnline = isStationOnline,
                JsonData = jsonData
            };

            dbContext.WeatherDataRecords.Add(record);
            await dbContext.SaveChangesAsync(stoppingToken);
            _logger.LogInformation("Záznam byl úspěšně uložen do databáze.");
        }
    }
}