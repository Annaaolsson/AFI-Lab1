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

	[HttpPost]
	public async Task<IActionResult> CreateAd(
		string firstName,
		string lastName,
		string phoneNumber,
		string deliveryAddress,
		string postalCode,
		string city,
		string title,
		string content,
		decimal itemPrice,
		decimal adPrice,
		int subscriptionNumber
	)
	{
		var advertiser = new Advertiser
		{
			AdvertiserType = "subscriber",
			SubscriptionNumber = subscriptionNumber,
			Name = firstName + " " + lastName,
			PhoneNumber = phoneNumber,
			DeliveryAddress = deliveryAddress,
			PostalCode = postalCode,
			City = city
		};

		_context.Advertisers.Add(advertiser);
		await _context.SaveChangesAsync();

		var ad = new Ad
		{
			Title = title,
			Content = content,
			ItemPrice = itemPrice,
			AdPrice = 0, // prenumeranter = gratis
			AdvertiserId = advertiser.Id
		};

		_context.Ads.Add(ad);
		await _context.SaveChangesAsync();

		return Content("Ad saved!");
	}
}