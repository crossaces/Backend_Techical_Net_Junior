using System;
using Backend.Data;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;
using Microsoft.Extensions.Configuration;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class SettingController : ControllerBase
{

    private readonly IConfiguration _configuration;

    public SettingController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet]
    public IActionResult GetAll()
    {

        var connectionString = _configuration.GetConnectionString("PlayerSQLServer");

        var response = new
        {         
            ConnectionString = connectionString
        };

        return Ok(response);
    }
}
