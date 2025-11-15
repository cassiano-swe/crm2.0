using System.ComponentModel.DataAnnotations;

namespace Crm.Api.Entities;

public sealed class Category()
{
    public int Id { get; init; }
    public string Name { get; init; } = "";
}