using Crm.Api.Database;
using Crm.Api.EndpointExtensions;
using Crm.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crm.Api.Features.Organizations;

public static class GetOrganizations
{
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
            app.MapGet("api/organizations/{id}", Handler).WithTags("Organizations");
        }
    }

    private static async Task<IResult> Handler(Guid id, Context context, HttpContext httpContext)
    {
        var result = await context.Organizations.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

        return result is not null ? Results.Ok(result) : Results.NotFound();
    }
}