using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MotrainIntegrationNETCore
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        private static string connectionString = "Server=YASINDU;Database=WebAPICore;Integrated Security=True;TrustServerCertificate=True;";



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasNoKey();
        }

        public class Item
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
