using Microsoft.EntityFrameworkCore;
using PulseImageProject.Data.Models;

namespace PulseImageProject.Data
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options)
			: base(options) { }

		public DbSet<Image> Images { get; set; }
	}
}
