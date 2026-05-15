using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prenumerantsystem.Data;
using Prenumerantsystem.Models;

namespace Prenumerantsystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrenumeranterController : ControllerBase
{
    private readonly AppDbContext _context;

    public PrenumeranterController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("{prenummer}")]
    public async Task<IActionResult> GetByPrenumerationsnummer(int prenummer)
    {
        var prenumerant = await _context.Prenumeranter
            .FirstOrDefaultAsync(p => p.Prenumerationsnummer == prenummer);

        if (prenumerant == null)
        {
            return NotFound("Ingen prenumerant hittades.");
        }

        return Ok(prenumerant);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Prenumerant prenumerant)
    {
        _context.Prenumeranter.Add(prenumerant);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetByPrenumerationsnummer),
            new { prenummer = prenumerant.Prenumerationsnummer },
            prenumerant
        );
    }
}