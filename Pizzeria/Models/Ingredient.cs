using System.ComponentModel.DataAnnotations;

namespace pizzeria_project.Models
{
    public class Ingredient
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public List<Pizza> Pizzas { get; set; }

        public Ingredient()
        {
        }

        public Ingredient(string name)
        {
            Name = name;
        }
    }
}
