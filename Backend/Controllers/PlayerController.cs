using System;
using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;
using Microsoft.Extensions.Configuration;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class PlayerController : ControllerBase
{

    private readonly ApplicationDBContext _context;
    private readonly IConfiguration _configuration;

    public PlayerController(ApplicationDBContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    [HttpGet]
    public IActionResult GetAll([FromQuery] string birthPlace = "")
    {

        IQueryable<Player> playersQuery = _context.Player;

        if (!string.IsNullOrEmpty(birthPlace))
        {
            playersQuery = playersQuery.Where(p => p.BirthPlace == birthPlace);
        }

        var players = playersQuery.ToList();
        var connectionString = _configuration.GetConnectionString("PlayerSQLServer");

        var response = new
        {
            data = players,
            ConnectionString = connectionString
        };

        return Ok(response);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(long id)
    {
        var player = _context.Player.Find(id);

        if (player == null)
        {
            return NotFound();
        }

        return Ok(player);
    }

    [HttpPost]
    public IActionResult AddPlayer([FromBody] Player player)
    {
        if (player == null)
        {
            return BadRequest("Player object is null");
        }

        _context.Player.Add(player);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetAll), new { id = player.Id }, player);
    }
}
