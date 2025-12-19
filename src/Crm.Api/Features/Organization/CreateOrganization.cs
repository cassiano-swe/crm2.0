using Crm.Api.Database;
using Crm.Api.EndpointExtensions;
using Crm.Api.Entities;
using Crm.Api.Entities.Validator;
using Crm.Api.Extensions;

namespace Crm.Api.Features.Organizations;

public static class CreateOrganizations
{
    internal record Request(
        string Name,
        string? Cnpj,
        string? Description,
        string? LegalName,
        int? CategoryId,
        int? LeadOriginId,
        int? SectorId,
        string? AvailablePhone,
        string? Email,
        string? FaxPhone,
        string? MobilePhone,
        int? PhoneExtension,
        string? Whatsapp,
        string? Website,
        string? Facebook,
        string? Instagram,
        string? Linkedin,
        string? Skype,
        string? Twitter,
        int? Cep,
        string? Country,
        string? State,
        string? City,
        string? Neighborhood,
        string? Street,
        string? Number,
        string? Complement
    );

    private record Response(
        Guid Id,
        string Name,
        string? Cnpj,
        string? Description,
        string? LegalName,
        Category? Category,
        LeadOrigin? LeadOrigin,
        Sector? Sector,
        string? AvailablePhone,
        string? Email,
        string? FaxPhone,
        string? MobilePhone,
        int? PhoneExtension,
        string? Whatsapp,
        string? Website,
        string? Facebook,
        string? Instagram,
        string? Linkedin,
        string? Skype,
        string? Twitter,
        int? Cep,
        string? Country,
        string? State,
        string? City,
        string? Neighborhood,
        string? Street,
        string? Number,
        string? Complement
    );

    public sealed class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("api/organizations", Handler).WithTags("Organizations");
        }
    }

    private static async Task<IResult> Handler(
        Request request,
        Context context,
        HttpContext httpContext
    )
    {
        var organization = Entities.Organization.CreateOrganization(
            name: request.Name,
            cnpj: request.Cnpj,
            description: request.Description,
            legalName: request.LegalName,
            category: request.CategoryId.HasValue
                ? await context.Categories.FindAsync(request.CategoryId.Value)
                : null,
            leadOrigin: request.LeadOriginId.HasValue
                ? await context.LeadOrigins.FindAsync(request.LeadOriginId.Value)
                : null,
            sector: request.SectorId.HasValue
                ? await context.Sectors.FindAsync(request.SectorId.Value)
                : null,
            availablePhone: request.AvailablePhone,
            email: request.Email,
            faxPhone: request.FaxPhone,
            mobilePhone: request.MobilePhone,
            phoneExtension: request.PhoneExtension,
            whatsapp: request.Whatsapp,
            website: request.Website,
            facebook: request.Facebook,
            instagram: request.Instagram,
            linkedin: request.Linkedin,
            skype: request.Skype,
            twitter: request.Twitter,
            cep: request.Cep,
            country: request.Country,
            state: request.State,
            city: request.City,
            neighborhood: request.Neighborhood,
            street: request.Street,
            number: request.Number,
            complement: request.Complement
        );

        var validator = new OrgValidator();
        var validationResult = await validator.ValidateAsync(organization);

        if (!validationResult.IsValid)
            return Results.BadRequest(validationResult.Errors);

        context.Organizations.Add(organization);

        await context.SaveChangesAsync();

        return Results.Created(
            $"{httpContext.Request.GetBaseUrl()}/api/organizations/{organization.Id}",
            new Response(
                Id: organization.Id,
                Name: organization.Name,
                Cnpj: organization.Cnpj,
                Description: organization.Description,
                LegalName: organization.LegalName,
                Category: organization.Category,
                LeadOrigin: organization.LeadOrigin,
                Sector: organization.Sector,
                AvailablePhone: organization.AvailablePhone,
                Email: organization.Email,
                FaxPhone: organization.FaxPhone,
                MobilePhone: organization.MobilePhone,
                PhoneExtension: organization.PhoneExtension,
                Whatsapp: organization.Whatsapp,
                Website: organization.Website,
                Facebook: organization.Facebook,
                Instagram: organization.Instagram,
                Linkedin: organization.Linkedin,
                Skype: organization.Skype,
                Twitter: organization.Twitter,
                Cep: organization.Cep,
                Country: organization.Country,
                State: organization.State,
                City: organization.City,
                Neighborhood: organization.Neighborhood,
                Street: organization.Street,
                Number: organization.Number,
                Complement: organization.Complement
            )
        );
    }
}
