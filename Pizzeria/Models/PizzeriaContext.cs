using Microsoft.EntityFrameworkCore;

namespace Pizzeria.Models
{
    public class PizzeriaContext : DbContext
    {
        public DbSet<string> Name { get; set; }
        public DbSet<string> Description { get; set; }
        public DbSet<string> Image { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Pizzeria;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }
    }
}
