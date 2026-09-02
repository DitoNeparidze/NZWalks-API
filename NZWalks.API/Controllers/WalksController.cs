using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;
using NZWalks.API.Models.Domain;
using NZWalks.API.Repositories;
using AutoMapper;
using NZWalks.API.CustomActionFilters;

namespace NZWalks.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WalksController : ControllerBase
{
    private readonly IWalkRepository _walkRepository;
    private readonly IMapper _mapper;

    public WalksController(IMapper mapper, IWalkRepository walkRepository)
    {
        _walkRepository = walkRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery] string? filterOn,
        [FromQuery] string? filterQuery,
        [FromQuery] string? sortBy,
        [FromQuery] bool? isAscending,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
    {
        var walksDomain = await _walkRepository.GetAllAsync(filterOn, filterQuery, sortBy,
            isAscending ?? true, pageNumber, pageSize);

        return Ok(_mapper.Map<List<WalkDto>>(walksDomain));
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var walkDomain = await _walkRepository.GetByIdAsync(id);
        if (walkDomain == null)
            return NotFound();

        return Ok(_mapper.Map<WalkDto>(walkDomain));
    }

    [HttpPost]
    [ValidateModel] //satestod, es isedac imushavebda amis garesehe
    public async Task<IActionResult> Create([FromBody]AddWalkRequestDto addWalkRequestDto)
    {
        var walkDomain = await _walkRepository.CreateAsync(_mapper.Map<Walk>(addWalkRequestDto));
        
        var walkDto = _mapper.Map<WalkDto>(walkDomain);
        return CreatedAtAction(nameof(GetById), new {id = walkDto.Id}, walkDto);
    }

    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
    {
        var walkDomain = await _walkRepository.UpdateAsync(id, _mapper.Map<Walk>(updateWalkRequestDto));
        if(walkDomain == null) 
            return NotFound();

        return Ok(_mapper.Map<WalkDto>(walkDomain));
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Delete([FromRoute]Guid id)
    {
        var deletedRows = await _walkRepository.DeleteAsync(id);
        if (deletedRows == 0)
            return NotFound();

        return NoContent();
    }
}
