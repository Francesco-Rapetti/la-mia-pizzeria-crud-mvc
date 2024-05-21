using pizzeria_project.Validations;

namespace pizzeria_project.Models
{
    public class PizzaFormModel
    {
        public Pizza Pizza { get; set; } = new Pizza();
        public List<Category>? Categories { get; set; }
        public List<Ingredient>? Ingredients { get; set; }

        [PizzaIngredientsValidation]
        public List<int>? SelectedIngredientsIds { get; set; } = new List<int>();


    }
}
