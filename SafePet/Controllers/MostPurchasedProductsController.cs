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
public class MostPurchasedProductsController: ControllerBase
{
    private readonly IMostPurchasedProductService _mostPurchasedProductService;
    private readonly IMapper _mapper;


    public MostPurchasedProductsController(IMostPurchasedProductService mostPurchasedProductService, IMapper mapper)
    {
        _mostPurchasedProductService = mostPurchasedProductService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<MostPurchasedProductResource>> GetAllAsync()
    {
        var mostPurchasedProducts = await _mostPurchasedProductService.ListAsync();
        var resources = _mapper.Map<IEnumerable<MostPurchasedProduct>, IEnumerable<MostPurchasedProductResource>>(mostPurchasedProducts);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveMostPurchasedProductResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var mostPurchasedProduct = _mapper.Map<SaveMostPurchasedProductResource, MostPurchasedProduct>(resource);

        var result = await _mostPurchasedProductService.SaveAsync(mostPurchasedProduct);

        if (!result.Success)
            return BadRequest(result.Message);

        var mostPurchasedProductResource = _mapper.Map<MostPurchasedProduct, MostPurchasedProductResource>(result.Resource);

        return Ok(mostPurchasedProductResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveMostPurchasedProductResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var mostPurchasedProduct = _mapper.Map<SaveMostPurchasedProductResource, MostPurchasedProduct>(resource);
        var result = await _mostPurchasedProductService.UpdateAsync(id, mostPurchasedProduct);

        if (!result.Success)
            return BadRequest(result.Message);

        var mostPurchasedProductResource = _mapper.Map<MostPurchasedProduct, MostPurchasedProductResource>(result.Resource);

        return Ok(mostPurchasedProductResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _mostPurchasedProductService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var mostPurchasedProductResource = _mapper.Map<MostPurchasedProduct, MostPurchasedProductResource>(result.Resource);

        return Ok(mostPurchasedProductResource);
    }
}