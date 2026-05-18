using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AFI_Lab1.Models;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json;
using AFI_Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using AFI_Lab1.Data;

namespace Annonssystem.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
	private readonly AppDbContext _context;

	public HomeController(ILogger<HomeController> logger, AppDbContext context)
	{
		_logger = logger;
		_context = context;
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
			return Content("Subscriber not found.");
		}

		var json = await response.Content.ReadAsStringAsync();

		var subscriber = JsonSerializer.Deserialize<Subscriber>(
			json,
			new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			}
		);

		if (subscriber == null)
		{
			return Content("Could not read subscriber data.");
		}

		var model = new CreateAdViewModel
		{
			SubscriptionNumber = subscriber.SubscriptionNumber,
			FirstName = subscriber.FirstName,
			LastName = subscriber.LastName,
			DeliveryAddress = subscriber.DeliveryAddress,
			PostalCode = subscriber.PostalCode,
			City = subscriber.City,
			AdPrice = 0
		};

		return View(model);
	}

	[HttpPost]
	public async Task<IActionResult> CreateAd(CreateAdViewModel model)
	{
		if (!ModelState.IsValid)
		{
			return View("GetSubscriber", model);
		}

		var advertiser = new Advertiser
		{
			AdvertiserType = "subscriber",
			SubscriptionNumber = model.SubscriptionNumber,
			Name = model.FirstName + " " + model.LastName,
			PhoneNumber = model.PhoneNumber,
			DeliveryAddress = model.DeliveryAddress,
			PostalCode = model.PostalCode,
			City = model.City
		};

		_context.Advertisers.Add(advertiser);
		await _context.SaveChangesAsync();

		var ad = new Ad
		{
			Title = model.Title,
			Content = model.Content,
			ItemPrice = model.ItemPrice,
			AdPrice = 0,
			AdvertiserId = advertiser.Id
		};

		_context.Ads.Add(ad);
		await _context.SaveChangesAsync();

		return Content("Ad saved!");
	}
}