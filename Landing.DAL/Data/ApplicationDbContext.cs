using Landing.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Landing.DAL.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Service> Services { get; set; }
		public DbSet<Portfoilo> Portfoilos { get; set; }
		public DbSet<Item> Items { get; set; } // Items فبمجرد عملت هديك , تلقائيا بعمل لل  Portfoilos هاي مش شرط احطها ,لانو اصلا في علاقة معها مع ال
	}
}
