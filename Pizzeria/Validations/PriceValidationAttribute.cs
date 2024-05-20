using System.ComponentModel.DataAnnotations;

namespace pizzeria_project.Validations
{
    public class PriceValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Price is required");
            }

            if (!double.TryParse(value.ToString(), out double price))
            {
                return new ValidationResult("Invalid price format");
            }

            if (price <= 0)
            {
                return new ValidationResult("Price cannot be negative or zero");
            }

            if (price > 1000)
            {
                return new ValidationResult("Price cannot be greater than 1000");
            }

            foreach (char c in value.ToString())
            {
                if (!char.IsDigit(c) && c != ',')
                {
                    return new ValidationResult("Invalid price format");
                }
            }

            return ValidationResult.Success;
        }
    }
}
