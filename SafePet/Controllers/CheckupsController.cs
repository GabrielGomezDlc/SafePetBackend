using AutoMapper;
using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.SafePet.Domain.Services;
using SafePetBackend.SafePet.Resources;
using SafePetBackend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using SafePetBackend.Security.Authorization.Attributes;

namespace SafePetBackend.SafePet.Controllers;
[Authorize]
[ApiController]
[Route("/api/v1/[controller]")]
public class CheckupsController: ControllerBase
{
    private readonly ICheckupService _checkupService;
    private readonly IMapper _mapper;


    public CheckupsController(ICheckupService checkupService, IMapper mapper)
    {
        _checkupService = checkupService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<CheckupResource>> GetAllAsync()
    {
        var checkups = await _checkupService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Checkup>, IEnumerable<CheckupResource>>(checkups);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveCheckupResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var checkup = _mapper.Map<SaveCheckupResource, Checkup>(resource);

        var result = await _checkupService.SaveAsync(checkup);

        if (!result.Success)
            return BadRequest(result.Message);

        var checkupResource = _mapper.Map<Checkup, CheckupResource>(result.Resource);

        return Ok(checkupResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCheckupResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var checkup = _mapper.Map<SaveCheckupResource, Checkup>(resource);
        var result = await _checkupService.UpdateAsync(id, checkup);

        if (!result.Success)
            return BadRequest(result.Message);

        var checkupResource = _mapper.Map<Checkup, CheckupResource>(result.Resource);

        return Ok(checkupResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _checkupService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var checkupResource = _mapper.Map<Checkup, CheckupResource>(result.Resource);

        return Ok(checkupResource);
    }
}