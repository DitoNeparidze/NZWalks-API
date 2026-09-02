using NZWalks.API.Models.Domain;
using NZWalks.API.Data;
using Microsoft.EntityFrameworkCore;
namespace NZWalks.API.Repositories;

public class SQLRegionRepository : IRegionRepository
{
    private readonly NZWalksDbContext _dbContext;

    public SQLRegionRepository(NZWalksDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Region>> GetAllAsync()
    {
        return await _dbContext.Regions.ToListAsync();
    }
    public async Task<Region?> GetByIdAsync(Guid id)
    {
       return await _dbContext.Regions.FindAsync(id);
    }

    public async Task<Region> CreateAsync(Region Region)
    {
        _dbContext.Regions.Add(Region);
        await _dbContext.SaveChangesAsync();
        return Region;
    }
    public async Task<Region?> UpdateAsync(Guid id, Region region)
    {
        var existingRegion = await _dbContext.Regions.FindAsync(id);
        if (existingRegion == null)
            return null;

        existingRegion.Code = region.Code;
        existingRegion.Name = region.Name;
        existingRegion.RegionImageUrl = region.RegionImageUrl;

        await _dbContext.SaveChangesAsync();
        return existingRegion;
    }

    public async Task<int> DeleteAsync(Guid id)
    {
        return await _dbContext.Regions.Where(x => x.Id == id).ExecuteDeleteAsync();
    }

}
