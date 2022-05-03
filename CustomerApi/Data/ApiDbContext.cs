using System;
using CustomerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Customer> Customers { get; set; }

        // connections to string to this db contex class
        // override OnConfi...
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            //remove

            optionsBuilder.UseSqlServer("server=localhost; database=Users;  user=sa; password=reallyStrongPwd123");
        }

    }
}

