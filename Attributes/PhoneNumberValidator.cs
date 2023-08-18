using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace EfCore.Attributes;

public class PhoneNumberValidator : ValidationAttribute
{
    private static readonly Regex regex = 
    new Regex(@"^\+?\d{1,4}?[-\s]?\(?\d{1,4}?\)?[-\s]?\d{1,4}[-\s]?\d{1,6}[-\s]?\d{1,6}$",
     RegexOptions.Compiled);
    public PhoneNumberValidator(){}

    public override bool IsValid(object? value)
    {
        if (value is null) 
            return false;

        return regex.IsMatch((string)value);
    }
    public override string FormatErrorMessage(string message = "")
    {
        return $"The phone number {message} is not valid";
    }
}
