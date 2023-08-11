using System.ComponentModel.DataAnnotations;

namespace EfCore.Attributes;

public class PriceValidator : ValidationAttribute
{
    private readonly decimal MinValue = 1;
    private readonly decimal MaxValue = 120000000;

    public PriceValidator(decimal minValue,decimal maxValue)
    {
        MinValue = minValue;
        MaxValue = maxValue;
    }
    public PriceValidator()
    {
        
    }

    public override bool IsValid(object? value)
    {
        //if (value == null || value.GetType() != typeof(decimal))
        //{
        //    return false;
        //}

        if (value is decimal price &&  price >  0 ) return true;

        return false;
    }

    public override string FormatErrorMessage(string name)
    {
        return $"{name} {MinValue} va {MaxValue} orasida bo'lishi shart !!";
    }
}
