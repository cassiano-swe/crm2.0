using Crm.Api.Database;
using Crm.Api.EndpointExtensions;
using Crm.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crm.Api.Features.Contacts;

public static class GetContacts
{
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
            app.MapGet("api/contacts/{id}", Handler).WithTags("Contacts");
        }
    }

    private static async Task<IResult> Handler(Guid id, Context context, HttpContext httpContext)
    {
        var result = await context.Contacts.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

        return result is not null ? Results.Ok(result) : Results.NotFound();
    }
}