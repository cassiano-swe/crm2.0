using Crm.Api.Database;
using Crm.Api.EndpointExtensions;

namespace Crm.Api.Features.Organizations;

public static class DeleteOrganizations
{
    public sealed class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapDelete("api/organizations", Handler).WithTags("Organizations");
        }
    }

    private static async Task<IResult> Handler(Guid id, Context context, HttpContext httpContext)
    {
        Entities.Organization? result = await context.Organizations.FindAsync(id);

        if (result is null)
            return Results.NotFound();
        else
        {
            context.Organizations.Remove(result);
            context.SaveChanges();
            return Results.NoContent();
        }
    }
}