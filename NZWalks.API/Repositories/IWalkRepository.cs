using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Repositories;

public interface IWalkRepository
{
    public Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null,
        bool isAscending = true, int pageNumber = 1, int pageSize = 10);
    public Task<Walk?> GetByIdAsync(Guid id);
    public Task<Walk> CreateAsync(Walk walk);
    public Task<Walk?> UpdateAsync(Guid id, Walk walk);
    public Task<int> DeleteAsync(Guid id);

}
