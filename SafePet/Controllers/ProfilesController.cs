using AutoMapper;
using SafePetBackend.SafePet.Domain.Services;
using SafePetBackend.SafePet.Resources;
using SafePetBackend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using SafePetBackend.Security.Authorization.Attributes;
using Profile = SafePetBackend.SafePet.Domain.Models.Profile;

namespace SafePetBackend.SafePet.Controllers;
[Authorize]
[ApiController]
[Route("/api/v1/[controller]")]
public class ProfilesController: ControllerBase
{
    private readonly IProfileService _profileService;
    private readonly IMapper _mapper;


    public ProfilesController(IProfileService profileService, IMapper mapper)
    {
        _profileService = profileService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ProfileResource>> GetAllAsync()
    {
        var profiles = await _profileService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Profile>, IEnumerable<ProfileResource>>(profiles);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveProfileResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var profile = _mapper.Map<SaveProfileResource, Profile>(resource);

        var result = await _profileService.SaveAsync(profile);

        if (!result.Success)
            return BadRequest(result.Message);

        var profileResource = _mapper.Map<Profile, ProfileResource>(result.Resource);

        return Ok(profileResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProfileResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var profile = _mapper.Map<SaveProfileResource, Profile>(resource);
        var result = await _profileService.UpdateAsync(id, profile);

        if (!result.Success)
            return BadRequest(result.Message);

        var profileResource = _mapper.Map<Profile, ProfileResource>(result.Resource);

        return Ok(profileResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _profileService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var profileResource = _mapper.Map<Profile, ProfileResource>(result.Resource);

        return Ok(profileResource);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _profileService.GetByIdAsync(id);
        var resource = _mapper.Map<Profile, ProfileResource>(user);
        return Ok(resource);
    }
}