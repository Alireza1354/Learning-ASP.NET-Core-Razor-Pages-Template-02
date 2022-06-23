using Domain.Account;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
	public class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
	{
		public DatabaseContext
			(Microsoft.EntityFrameworkCore.DbContextOptions<DatabaseContext> options) : base(options: options)
		{
			//Database.EnsureCreated();
		}

		protected override void OnConfiguring
			(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating
			(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
		{
		}

		public virtual DbSet<Role> Role { get; set; }
	}
}
