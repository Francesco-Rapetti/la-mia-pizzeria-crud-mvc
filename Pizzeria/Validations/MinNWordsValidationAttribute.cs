using System.ComponentModel.DataAnnotations;

namespace pizzeria_project.Validations
{
    public class MinNWordsValidationAttribute : ValidationAttribute
    {
        public int NumberOfWords { get; set; }

        public MinNWordsValidationAttribute(int numberOfWords)
        {
            NumberOfWords = numberOfWords;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Number of words is required");
            }

            if (value.ToString()?.Split(" ").Length < NumberOfWords)
            {
                return new ValidationResult($"Must have at least {NumberOfWords} words");
            }

            return ValidationResult.Success;
        }
    }
}
