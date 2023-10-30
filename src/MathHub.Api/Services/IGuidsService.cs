namespace MathHub.Api.Services;

internal interface IGuidsService
{
    Task<IReadOnlyCollection<Guid>> GetAsync();

    Task<Guid> AddAsync();

    Task PurgeAsync();
}
