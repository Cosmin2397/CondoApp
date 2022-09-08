using CondoApp.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace CondoApp.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Building> Buildings { get; set; }

        public DbSet<Flats> Flats { get; set; }

        public DbSet<Expense> Expenses { get; set; }
    }
}
