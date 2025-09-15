namespace MathHub.Api.Repositories;

internal sealed class GuidsRepository : IGuidsRepository
{
    private readonly List<Guid> _guids = [];

    public Task<IReadOnlyCollection<Guid>> GetAsync() => Task.FromResult<IReadOnlyCollection<Guid>>(_guids);

    public Task<Guid> AddAsync()
    {
        var newGuid = Guid.NewGuid();
        _guids.Add(newGuid);

        return Task.FromResult(newGuid);
    }

    public Task PurgeAsync()
    {
        _guids.Clear();

        return Task.CompletedTask;
    }
}
