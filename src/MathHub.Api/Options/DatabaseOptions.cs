using System.ComponentModel.DataAnnotations;

namespace MathHub.Api.Options;

internal class DatabaseOptions
{
    [Required]
    public string? ConnectionString { get; init; }
}
