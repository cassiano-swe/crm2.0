namespace Crm.Api.Extensions;

public static class HttpRequestExtensions
{
    public static string GetBaseUrl(this HttpRequest request)
    {
        return $"{request.Scheme}://{request.Host}{request.PathBase}";
    }
}