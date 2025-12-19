namespace Crm.Api.Entities;

public class Organization(string name)
{
    public Guid Id { get; init; }
    public string Name { get; init; } = name;
    public string? Cnpj { get; init; }
    public string? Description { get; init; }
    public string? LegalName { get; init; }
    public Category? Category { get; init; }
    public LeadOrigin? LeadOrigin { get; init; }
    public Sector? Sector { get; init; }
    public string? AvailablePhone { get; init; }
    public string? Email { get; init; }
    public string? FaxPhone { get; init; }
    public string? MobilePhone { get; init; }
    public int? PhoneExtension { get; init; }
    public string? Whatsapp { get; init; }
    public string? Website { get; init; }
    public string? Facebook { get; init; }
    public string? Instagram { get; init; }
    public string? Linkedin { get; init; }
    public string? Skype { get; init; }
    public string? Twitter { get; init; }
    public int? Cep { get; init; }
    public string? Country { get; init; }
    public string? State { get; init; }
    public string? City { get; init; }
    public string? Neighborhood { get; init; }
    public string? Street { get; init; }
    public string? Number { get; init; }
    public string? Complement { get; set; }

    public static Organization CreateOrganization(
        string name,
        string? cnpj,
        string? description,
        string? legalName,
        Category? category,
        LeadOrigin? leadOrigin,
        Sector? sector,
        string? availablePhone,
        string? email,
        string? faxPhone,
        string? mobilePhone,
        int? phoneExtension,
        string? whatsapp,
        string? website,
        string? facebook,
        string? instagram,
        string? linkedin,
        string? skype,
        string? twitter,
        int? cep,
        string? country,
        string? state,
        string? city,
        string? neighborhood,
        string? street,
        string? number,
        string? complement
    ) =>
        new(name: name)
        {
            Id = new Guid(),
            Cnpj = cnpj,
            Description = description,
            LegalName = legalName,
            Category = category,
            LeadOrigin = leadOrigin,
            Sector = sector,
            AvailablePhone = availablePhone,
            Email = email,
            FaxPhone = faxPhone,
            MobilePhone = mobilePhone,
            PhoneExtension = phoneExtension,
            Whatsapp = whatsapp,
            Website = website,
            Facebook = facebook,
            Instagram = instagram,
            Linkedin = linkedin,
            Skype = skype,
            Twitter = twitter,
            Cep = cep,
            Country = country,
            State = state,
            City = city,
            Neighborhood = neighborhood,
            Street = street,
            Number = number,
            Complement = complement,
        };

    public static Organization CreateOrganization(
        Guid id,
        string name,
        string? cnpj,
        string? description,
        string? legalName,
        Category? category,
        LeadOrigin? leadOrigin,
        Sector? sector,
        string? availablePhone,
        string? email,
        string? faxPhone,
        string? mobilePhone,
        int? phoneExtension,
        string? whatsapp,
        string? website,
        string? facebook,
        string? instagram,
        string? linkedin,
        string? skype,
        string? twitter,
        int? cep,
        string? country,
        string? state,
        string? city,
        string? neighborhood,
        string? street,
        string? number,
        string? complement
    ) =>
        new(name: name)
        {
            Id = id,
            Cnpj = cnpj,
            Description = description,
            LegalName = legalName,
            Category = category,
            LeadOrigin = leadOrigin,
            Sector = sector,
            AvailablePhone = availablePhone,
            Email = email,
            FaxPhone = faxPhone,
            MobilePhone = mobilePhone,
            PhoneExtension = phoneExtension,
            Whatsapp = whatsapp,
            Website = website,
            Facebook = facebook,
            Instagram = instagram,
            Linkedin = linkedin,
            Skype = skype,
            Twitter = twitter,
            Cep = cep,
            Country = country,
            State = state,
            City = city,
            Neighborhood = neighborhood,
            Street = street,
            Number = number,
            Complement = complement,
        };
}
