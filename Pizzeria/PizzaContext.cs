using Microsoft.EntityFrameworkCore;
using pizzeria_project.Models;

namespace pizzeria_project
{
    public class PizzaContext : DbContext
    {
        public DbSet<Pizzeria> Pizzerias { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Pizzeria;Integrated Security=True;Trust Server Certificate=True");
        }
    }
}
