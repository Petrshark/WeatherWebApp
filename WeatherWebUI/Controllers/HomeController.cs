using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ManualDownloadService _manualDownloadService;

    public HomeController(ApplicationDbContext dbContext, ManualDownloadService manualDownloadService)
    {
        _dbContext = dbContext;
        _manualDownloadService = manualDownloadService;
    }

    public async Task<IActionResult> Index()
    {
        var weatherRecords = await _dbContext.WeatherDataRecords
            .OrderByDescending(r => r.DownloadTimestamp)
            .ToListAsync();

        return View(weatherRecords);
    }

    [HttpPost]
    public IActionResult DownloadData()
    {
        _manualDownloadService.SignalDownload();
        return RedirectToAction("Index");
    }
}