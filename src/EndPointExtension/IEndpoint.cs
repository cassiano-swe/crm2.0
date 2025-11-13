namespace Crm.Api.EndpointExtensions;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}