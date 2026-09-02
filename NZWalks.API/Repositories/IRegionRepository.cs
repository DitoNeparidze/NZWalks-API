using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories;

public interface IRegionRepository
{
    public Task<List<Region>> GetAllAsync();
    public Task<Region?> GetByIdAsync(Guid id);
    public Task<Region> CreateAsync(Region Region);
    public Task<Region?> UpdateAsync(Guid id, Region region);
    public Task<int> DeleteAsync(Guid id);
}
