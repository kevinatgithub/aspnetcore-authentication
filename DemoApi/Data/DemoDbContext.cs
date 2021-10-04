using DemoApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoApi.Data
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<City> City { get; set; }
    }
}
