﻿using AutoMapper;
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
public class VetsController: ControllerBase
{
    private readonly IVetService _vetService;
    private readonly IMapper _mapper;


    public VetsController(IVetService vetService, IMapper mapper)
    {
        _vetService = vetService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<VetResource>> GetAllAsync()
    {
        var vets = await _vetService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Vet>, IEnumerable<VetResource>>(vets);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveVetResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var vet = _mapper.Map<SaveVetResource, Vet>(resource);

        var result = await _vetService.SaveAsync(vet);

        if (!result.Success)
            return BadRequest(result.Message);

        var vetResource = _mapper.Map<Vet, VetResource>(result.Resource);

        return Ok(vetResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveVetResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var vet = _mapper.Map<SaveVetResource, Vet>(resource);
        var result = await _vetService.UpdateAsync(id, vet);

        if (!result.Success)
            return BadRequest(result.Message);

        var vetResource = _mapper.Map<Vet, VetResource>(result.Resource);

        return Ok(vetResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _vetService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var vetResource = _mapper.Map<Vet, VetResource>(result.Resource);

        return Ok(vetResource);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _vetService.GetByIdAsync(id);
        var resource = _mapper.Map<Vet,VetResource>(user);
        return Ok(resource);
    }
}