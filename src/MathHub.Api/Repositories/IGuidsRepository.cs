namespace MathHub.Api.Repositories;

internal interface IGuidsRepository
{
    Task<IReadOnlyCollection<Guid>> GetAsync();

    Task<Guid> AddAsync();

    Task PurgeAsync();
}
