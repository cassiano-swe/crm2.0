using Crm.Api.Database;
using Crm.Api.EndpointExtensions;
using Crm.Api.Entities;
using Crm.Api.Entities.Validator;
using Crm.Api.Extensions;

namespace Crm.Api.Features.Contacts;

public static class CreateContacts
{
    internal record Request(
        string Name,
        string? Cpf,
        string? JobTitle,
        DateTime? BirthDate,
        string? Description,
        int? CategoryId,
        int? LeadOriginId,
        string? AvailablePhone,
        string? Email,
        string? Facebook,
        string? FaxPhone,
        string? Instagram,
        string? Linkedin,
        string? MobilePhone,
        int? PhoneExtension,
        string? Skype,
        string? Twitter,
        string? Whatsapp,
        string? WorkPhone
    );

    private record Response(
        Guid Id,
        string Name,
        string? Cpf,
        string? JobTitle,
        DateTime? BirthDate,
        string? Description,
        Category? Category,
        LeadOrigin? LeadOrigin,
        string? AvailablePhone,
        string? Email,
        string? Facebook,
        string? FaxPhone,
        string? Instagram,
        string? Linkedin,
        string? MobilePhone,
        int? PhoneExtension,
        string? Skype,
        string? Twitter,
        string? Whatsapp,
        string? WorkPhone
    );

    public sealed class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("api/contacts", Handler).WithTags("Contacts");
        }
    }

    private static async Task<IResult> Handler(
        Request request,
        Context context,
        HttpContext httpContext
    )
    {
        var contact = Entities.Contact.CreateContact(
            name: request.Name,
            cpf: request.Cpf,
            jobTitle: request.JobTitle,
            birthDate: request.BirthDate,
            description: request.Description,
            category: request.CategoryId.HasValue
                ? await context.Categories.FindAsync(request.CategoryId.Value)
                : null,
            leadOrigin: request.LeadOriginId.HasValue
                ? await context.LeadOrigins.FindAsync(request.LeadOriginId.Value)
                : null,
            availablePhone: request.AvailablePhone,
            email: request.Email,
            facebook: request.Facebook,
            faxPhone: request.FaxPhone,
            instagram: request.Instagram,
            linkedin: request.Linkedin,
            mobilePhone: request.MobilePhone,
            phoneExtension: request.PhoneExtension,
            skype: request.Skype,
            twitter: request.Twitter,
            whatsapp: request.Whatsapp,
            workPhone: request.WorkPhone
        );

        var validator = new ContactValidator();
        var validationResult = await validator.ValidateAsync(contact);

        if (!validationResult.IsValid)
            return Results.BadRequest(validationResult.Errors);

        context.Contacts.Add(contact);

        await context.SaveChangesAsync();

        return Results.Created(
            $"{httpContext.Request.GetBaseUrl()}/api/contacts/{contact.Id}",
            new Response(
                Id: contact.Id,
                Name: contact.Name,
                Cpf: contact.Cpf,
                JobTitle: contact.JobTitle,
                BirthDate: contact.BirthDate,
                Description: contact.Description,
                Category: contact.Category,
                LeadOrigin: contact.LeadOrigin,
                AvailablePhone: contact.AvailablePhone,
                Email: contact.Email,
                Facebook: contact.Facebook,
                FaxPhone: contact.FaxPhone,
                Instagram: contact.Instagram,
                Linkedin: contact.Linkedin,
                MobilePhone: contact.MobilePhone,
                PhoneExtension: contact.PhoneExtension,
                Skype: contact.Skype,
                Twitter: contact.Twitter,
                Whatsapp: contact.Whatsapp,
                WorkPhone: contact.WorkPhone
            )
        );
    }
}
