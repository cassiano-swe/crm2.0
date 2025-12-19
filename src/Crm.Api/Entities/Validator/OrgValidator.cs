using FluentValidation;

namespace Crm.Api.Entities.Validator;

public class OrgValidator : AbstractValidator<Organization>
{
    public OrgValidator()
    {
        RuleFor(contact => contact.Name).NotEmpty();
        RuleFor(contact => contact.Cnpj)
            .Must(IsValidCnpj)
            .When(p => !string.IsNullOrWhiteSpace(p.Cnpj));

        RuleFor(contact => contact.Email)
            .Must(IsValidEmail)
            .When(contact => !string.IsNullOrWhiteSpace(contact.Email));
    }

    private static bool IsValidCnpj(string? cnpj)
    {
        cnpj = new string([.. cnpj!.Where(char.IsDigit)]);

        if (cnpj.Length != 14 || cnpj.All(c => c == cnpj[0]))
            return false;

        var factor1 = new[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        var factor2 = new[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        var tempCnpj = cnpj.Substring(0, 12);
        var sum = 0;

        for (var i = 0; i < 12; i++)
            sum += int.Parse(tempCnpj[i].ToString()) * factor1[i];

        var remainder = sum % 11;
        var digit1 = remainder < 2 ? 0 : 11 - remainder;

        tempCnpj += digit1;
        sum = 0;

        for (var i = 0; i < 13; i++)
            sum += int.Parse(tempCnpj[i].ToString()) * factor2[i];

        remainder = sum % 11;
        var digit2 = remainder < 2 ? 0 : 11 - remainder;

        return cnpj.EndsWith($"{digit1}{digit2}");
    }

    private static bool IsValidEmail(string? email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}
