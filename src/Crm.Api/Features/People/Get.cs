using Crm.Api.EndpointExtensions;

namespace Crm.Api.Features.People;

public sealed class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/", () => Results.Accepted());
        }
    }