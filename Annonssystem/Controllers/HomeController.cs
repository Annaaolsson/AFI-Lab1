using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AFI_Lab1.Models;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json;
using Annonssystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace Annonssystem.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

	public async Task<IActionResult> GetSubscriber(int subscriptionNumber)
    {
        using var client = new HttpClient();

        var response = await client.GetAsync(
            $"http://localhost:5249/api/subscribers/{subscriptionNumber}"
        );

        if (!response.IsSuccessStatusCode)
        {
            return NotFound("Subscriber could not be found.");
        }

        var json = await response.Content.ReadAsStringAsync();

        var subscriber = JsonSerializer.Deserialize<Subscriber>(
            json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }
        );

        return View(subscriber);
    }
}