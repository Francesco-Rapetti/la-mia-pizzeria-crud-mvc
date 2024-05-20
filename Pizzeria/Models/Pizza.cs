using pizzeria_project.Validations;
using System.ComponentModel.DataAnnotations;

namespace pizzeria_project.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        [Display(Name = "Pizza Name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a description")]
        [Display(Name = "Pizza Description")]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        [MinNWordsValidation(5)]
        public string Description { get; set; }

        //[Required(ErrorMessage = "Please enter an image")]
        //[Display(Name = "Pizza Image")]
        //[StringLength(500, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        public string Image { get; set; }

        [PriceValidation]
        [Required(ErrorMessage = "Please enter a price")]
        [Display(Name = "Pizza Price")]
        public double Price { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public Pizza()
        {

        }

        public Pizza(string name, string description, double price, int? categoryId, string image = "/img/pizza-placeholder.png")
        {
            this.Name = name;
            this.Description = description;
            this.Image = image;
            using (PizzaContext db = new PizzaContext())
            this.CategoryId = categoryId;
            this.Price = Math.Round(price, 2);
        }

        public string GetCategory() => this.Category?.Name ?? "Unknown";
    }
}
