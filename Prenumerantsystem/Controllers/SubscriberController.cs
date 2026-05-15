using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prenumerantsystem.Data;
using Prenumerantsystem.Models;

namespace Prenumerantsystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubscribersController : ControllerBase
{
    private readonly AppDbContext _context;

    public SubscribersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("{subscriptionNumber}")]
    public async Task<IActionResult> GetSubscriber(int subscriptionNumber)
    {
        var subscriber = await _context.Subscribers
            .FirstOrDefaultAsync(s => s.SubscriptionNumber == subscriptionNumber);

        if (subscriber == null)
        {
            return NotFound("Subscriber not found.");
        }

        return Ok(subscriber);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSubscriber(Subscriber subscriber)
    {
        _context.Subscribers.Add(subscriber);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetSubscriber),
            new { subscriptionNumber = subscriber.SubscriptionNumber },
            subscriber
        );
    }
}