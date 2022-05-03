using System;
using Microsoft.EntityFrameworkCore;
using VehichleApi.Models;

namespace VehichleApi.Data
{
    // config för databas
	public class ApiDbContext : DbContext
	{
		public DbSet<Vehicle> Vehicles { get; set; }

        // connections to string to this db contex class
        // override OnConfi...
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            //remove

            optionsBuilder.UseSqlServer("server=localhost; database=Vehicle;  user=sa; password=reallyStrongPwd123");
            // @"Server=(localdb)\MSSQLLocalDB;Database=dbnamn;"
            // server object explorer windows
        }
    }
}
// Sql server object explorer
