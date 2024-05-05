using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data;

public class ApplicationDBContext : DbContext
{
	public ApplicationDBContext(DbContextOptions dbContextOptions) : 
		base(dbContextOptions)
	{

	}


public DbSet<Player> Player { get; set; } = null!;
}
