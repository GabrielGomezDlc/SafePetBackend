using AutoMapper;
using SafePetBackend.Security.Authorization.Attributes;
using SafePetBackend.Security.Domain.Models;
using SafePetBackend.Security.Domain.Services;
using SafePetBackend.Security.Domain.Services.Communication;
using SafePetBackend.Security.Resources;
using Microsoft.AspNetCore.Mvc;

namespace SafePetBackend.Security.Controllers;

[Authorize]
[ApiController]
[Route("/api/v1/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UsersController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    
    [AllowAnonymous]
    [HttpPost("sign-up")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        await _userService.RegisterAsync(request);
        return Ok(new { message = "Registration successful" });
    }
    
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.ListAsync();
        var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
        return Ok(resources);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        var resource = _mapper.Map<User, UserResource>(user);
        return Ok(resource);
    }
    
    
    [AllowAnonymous]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateRequest request)
    {
        await _userService.UpdateAsync(id, request);
        return Ok(new { message = "User updated successfully" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _userService.DeleteAsync(id);
        return Ok(new { message = "User deleted successfully" });
    }
}