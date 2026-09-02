using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class RegionsController : ControllerBase
{
    private readonly IRegionRepository _regionRepository;
    private readonly IMapper _mapper;

    public RegionsController(IRegionRepository regionRepository, IMapper mapper)
    { 
        _regionRepository = regionRepository;
        _mapper = mapper;
    }

    //GET: https://localhost:7058/api/regions
    [HttpGet]
    [Authorize(Roles = "Reader")]

    public async Task<IActionResult> GetAllAsync()
    {
        var regionsDomain = await _regionRepository.GetAllAsync();

        return Ok(_mapper.Map<List<RegionDto>>(regionsDomain));
    }

    //GET: https://localhost:7058/api/regions/{id}
    [HttpGet("{id:Guid}")]
    [Authorize(Roles = "Reader")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var region = await _regionRepository.GetByIdAsync(id);
        if (region == null)
            return NotFound();

        return Ok(_mapper.Map<RegionDto>(region));
    }

    //POST: https://localhost:7058/api/regions
    [HttpPost]
    [Authorize(Roles = "Writer")]
    public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
    {
        var regionDomain = await _regionRepository.CreateAsync(_mapper.Map<Region>(addRegionRequestDto));

        var regionDto = _mapper.Map<RegionDto>(regionDomain);

        return CreatedAtAction(nameof(GetById), new {id = regionDto.Id}, regionDto);
    }

    //PUT: https://localhost:7058/api/regions/{id}
    [HttpPut("{id:Guid}")]
    [Authorize(Roles = "Writer")]
    public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody]UpdateRegionRequestDto updateRequestDto)
    {
        var regionDomain = _mapper.Map<Region>(updateRequestDto);

        regionDomain = await _regionRepository.UpdateAsync(id, regionDomain);

        if (regionDomain == null)
            return NotFound();

        return Ok(_mapper.Map<RegionDto>(regionDomain));
    }

    //DELETE: https://localhost:7058/api/regions/{id}
    [HttpDelete("{id:Guid}")]
    [Authorize(Roles = "Writer")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var deletedRows = await _regionRepository.DeleteAsync(id);

        if (deletedRows == 0)
            return NotFound();

        return NoContent();
    }
}
