using Crm.Api.Database;
using Crm.Api.EndpointExtensions;
using Crm.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crm.Api.Features.Contacts;

public static class DeleteContacts
{
    public sealed class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapDelete("api/contacts", Handler).WithTags("Contacts");
        }
    }

    private static async Task<IResult> Handler(Guid id, Context context, HttpContext httpContext)
    {
        Entities.Contact? result = await context.Contacts.FindAsync(id);

        if (result is null)
            return Results.NotFound();
        else
        {
            context.Contacts.Remove(result);
            context.SaveChanges();
            return Results.NoContent();
        }
    }
}