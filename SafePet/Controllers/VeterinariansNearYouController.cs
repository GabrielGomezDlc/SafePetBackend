using AutoMapper;
using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.SafePet.Domain.Services;
using SafePetBackend.SafePet.Resources;
using SafePetBackend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace SafePetBackend.SafePet.Controllers;

[Route("/api/v1/[controller]")]
public class VeterinariansNearYouController: ControllerBase
{
    private readonly IVeterinarianNearYouService _veterinarianNearYouService;
    private readonly IMapper _mapper;


    public VeterinariansNearYouController(IVeterinarianNearYouService veterinarianNearYouService, IMapper mapper)
    {
        _veterinarianNearYouService = veterinarianNearYouService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<VeterinarianNearYouResource>> GetAllAsync()
    {
        var veterinarianNearYous = await _veterinarianNearYouService.ListAsync();
        var resources = _mapper.Map<IEnumerable<VeterinarianNearYou>, IEnumerable<VeterinarianNearYouResource>>(veterinarianNearYous);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveVeterinarianNearYouResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var veterinarianNearYou = _mapper.Map<SaveVeterinarianNearYouResource, VeterinarianNearYou>(resource);

        var result = await _veterinarianNearYouService.SaveAsync(veterinarianNearYou);

        if (!result.Success)
            return BadRequest(result.Message);

        var veterinarianNearYouResource = _mapper.Map<VeterinarianNearYou, VeterinarianNearYouResource>(result.Resource);

        return Ok(veterinarianNearYouResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveVeterinarianNearYouResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var veterinarianNearYou = _mapper.Map<SaveVeterinarianNearYouResource, VeterinarianNearYou>(resource);
        var result = await _veterinarianNearYouService.UpdateAsync(id, veterinarianNearYou);

        if (!result.Success)
            return BadRequest(result.Message);

        var veterinarianNearYouResource = _mapper.Map<VeterinarianNearYou, VeterinarianNearYouResource>(result.Resource);

        return Ok(veterinarianNearYouResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _veterinarianNearYouService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var veterinarianNearYouResource = _mapper.Map<VeterinarianNearYou, VeterinarianNearYouResource>(result.Resource);

        return Ok(veterinarianNearYouResource);
    }
}