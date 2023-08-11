using System.ComponentModel.DataAnnotations;

namespace EfCore.Attributes;

/// <summary>
/// Validates that a string value is between a minimum and maximum length.
/// </summary>
public class StringValidation : ValidationAttribute
{
    public int MinLength { get; set; } = 1;
    public int MaxLength { get; set; } = 10;

    public StringValidation(int minLength, int maxLength)
    {
        MinLength = minLength;
        MaxLength = maxLength;
    }

    public StringValidation(int minLength, int maxLength, string ErrorMessage) : this(minLength, maxLength)
    {
    }

    public StringValidation()
    {
        
    }

    public override bool IsValid(object? value)
    {
        return !string.IsNullOrEmpty(value as string) && value is string text && text.Length >= MinLength && text.Length <= MaxLength;
    }

    public override string FormatErrorMessage(string message)
    {
        return $"{ErrorMessageString} (MinLength: {MinLength}, MaxLength: {MaxLength})";
    }
}