using System.ComponentModel.DataAnnotations;

namespace pizzeria_project.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        public List<Pizza> Pizzas { get; set; }

        public Category(string name, string color)
        {
            Name = name;
            Color = color;
        }
    }
}
