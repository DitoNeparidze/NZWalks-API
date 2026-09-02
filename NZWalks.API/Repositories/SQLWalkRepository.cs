using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Repositories;

public class SQLWalkRepository : IWalkRepository
{
    private readonly NZWalksDbContext _dbContext;

    public SQLWalkRepository(NZWalksDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<Walk>> GetAllAsync(
        string? filterOn = null, 
        string? filterQuery = null,
        string? sortBy = null,
        bool isAscending = true,
        int pageNumber = 1,
        int pageSize = 10)
    {
        var walks = _dbContext.Walks
            .Include(x=> x.Region)
            .Include(x=>x.Difficulty)
            .AsQueryable();

        if(!string.IsNullOrWhiteSpace(filterOn) && !string.IsNullOrWhiteSpace(filterQuery))
        {
            if(filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                walks = walks.Where(x => x.Name.Contains(filterQuery));

            else if(filterOn.Equals("Description", StringComparison.OrdinalIgnoreCase))
                walks = walks.Where(x => x.Description.Contains(filterQuery));
        }

        if(!string.IsNullOrWhiteSpace(sortBy))
        {
            if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                walks = isAscending 
                    ? walks.OrderBy(x => x.Name)
                    : walks.OrderByDescending(x => x.Name);

            else if (sortBy.Equals("LengthInKm", StringComparison.OrdinalIgnoreCase))
                walks = isAscending
                    ? walks.OrderBy(x=> x.LengthInKm)
                    : walks.OrderByDescending(x=> x.LengthInKm);
        }
        else
        {
            walks = walks.OrderBy(x => x.Id);
        }

        pageNumber = Math.Max(pageNumber, 1);
        pageSize = Math.Clamp(pageSize, 1, 100);

        var skipCount = (pageNumber - 1) * pageSize;
        walks = walks.Skip(skipCount).Take(pageSize);

         
        return await walks.ToListAsync();
    }

    public async Task<Walk?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Walks
            .Include(x => x.Region)
            .Include(x => x.Difficulty)
            .FirstOrDefaultAsync(x=> x.Id ==id);
    }


    public async Task<Walk> CreateAsync(Walk walk)
    {
        _dbContext.Walks.Add(walk);
        await _dbContext.SaveChangesAsync();

        var createdWalk = await GetByIdAsync(walk.Id);
        return createdWalk;
    }

    public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
    {
        var walkDomain = await _dbContext.Walks
            .Include(x => x.Region)
            .Include(x => x.Difficulty)
            .FirstOrDefaultAsync(x => x.Id == id);
        if (walkDomain == null)
            return null;

        walkDomain.Name = walk.Name; 
        walkDomain.Description = walk.Description;
        walkDomain.LengthInKm = walk.LengthInKm;
        walkDomain.WalkImageUrl = walk.WalkImageUrl;
        walkDomain.DifficultyId = walk.DifficultyId;
        walkDomain.RegionId = walk.RegionId;
        await _dbContext.SaveChangesAsync();

        return walkDomain;
    }

    public async Task<int> DeleteAsync(Guid id)
    {
        return await _dbContext.Walks.Where(x => x.Id == id).ExecuteDeleteAsync(); 
    }
}
