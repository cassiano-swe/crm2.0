namespace Crm.Api.Entities;

public class Contact(string name)
{
    public Guid Id { get; init; }
    public string Name { get; init; } = name;
    public string? Cpf { get; init; }
    public string? JobTitle { get; init; }
    public DateTime? BirthDate { get; init; }
    public string? Description { get; init; }
    public Category? Category { get; init; }
    public LeadOrigin? LeadOrigin { get; init; }
    public string? AvailablePhone { get; init; }
    public string? Email { get; init; }
    public string? Facebook { get; init; }
    public string? FaxPhone { get; init; }
    public string? Instagram { get; init; }
    public string? Linkedin { get; init; }
    public string? MobilePhone { get; init; }
    public int? PhoneExtension { get; init; }
    public string? Skype { get; init; }
    public string? Twitter { get; init; }
    public string? Whatsapp { get; init; }
    public string? WorkPhone { get; init; }

    public static Contact CreateContact(
        string name,
        string? cpf,
        string? jobTitle,
        DateTime? birthDate,
        string? description,
        Category? category,
        LeadOrigin? leadOrigin,
        string? availablePhone,
        string? email,
        string? facebook,
        string? faxPhone,
        string? instagram,
        string? linkedin,
        string? mobilePhone,
        int? phoneExtension,
        string? skype,
        string? twitter,
        string? whatsapp,
        string? workPhone
    ) =>
        new(name: name)
        {
            Id = new Guid(),
            Cpf = cpf,
            JobTitle = jobTitle,
            BirthDate = birthDate,
            Description = description,
            Category = category,
            LeadOrigin = leadOrigin,
            AvailablePhone = availablePhone,
            Email = email,
            Facebook = facebook,
            FaxPhone = faxPhone,
            Instagram = instagram,
            Linkedin = linkedin,
            MobilePhone = mobilePhone,
            PhoneExtension = phoneExtension,
            Skype = skype,
            Twitter = twitter,
            Whatsapp = whatsapp,
            WorkPhone = workPhone,
        };

    public static Contact CreateContact(
        Guid Id,
        string name,
        string? cpf,
        string? jobTitle,
        DateTime? birthDate,
        string? description,
        Category? category,
        LeadOrigin? leadOrigin,
        string? availablePhone,
        string? email,
        string? facebook,
        string? faxPhone,
        string? instagram,
        string? linkedin,
        string? mobilePhone,
        int? phoneExtension,
        string? skype,
        string? twitter,
        string? whatsapp,
        string? workPhone
    )
    {
        return new(name: name)
        {
            Id = Id,
            Cpf = cpf,
            JobTitle = jobTitle,
            BirthDate = birthDate,
            Description = description,
            Category = category,
            LeadOrigin = leadOrigin,
            AvailablePhone = availablePhone,
            Email = email,
            Facebook = facebook,
            FaxPhone = faxPhone,
            Instagram = instagram,
            Linkedin = linkedin,
            MobilePhone = mobilePhone,
            PhoneExtension = phoneExtension,
            Skype = skype,
            Twitter = twitter,
            Whatsapp = whatsapp,
            WorkPhone = workPhone,
        };
    }
}
