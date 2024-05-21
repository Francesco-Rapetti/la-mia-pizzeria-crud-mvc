using System.ComponentModel.DataAnnotations;

namespace pizzeria_project.Validations
{
    public class PizzaIngredientsValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Ingredients are required");
            }

            if ((value is List<int> list))
            {
                if (list.Count < 1)
                    return new ValidationResult("Must have at least 1 ingredient");
            }
            

            return ValidationResult.Success;
        }
    }
}
