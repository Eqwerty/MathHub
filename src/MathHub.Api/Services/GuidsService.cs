using MathHub.Api.Repositories;

namespace MathHub.Api.Services;

internal sealed class GuidsService : IGuidsService
{
    private readonly IGuidsRepository _guidsRepository;

    public GuidsService(IGuidsRepository guidsRepository)
    {
        _guidsRepository = guidsRepository;
    }

    public Task<IReadOnlyCollection<Guid>> GetAsync() => _guidsRepository.GetAsync();

    public Task<Guid> AddAsync() => _guidsRepository.AddAsync();

    public Task PurgeAsync() => _guidsRepository.PurgeAsync();
}
