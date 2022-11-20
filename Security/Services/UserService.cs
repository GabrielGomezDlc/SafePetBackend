using AutoMapper;
using SafePetBackend.SafePet.Domain.Repositories;
using SafePetBackend.Security.Authorization.Handlers.Interfaces;
using SafePetBackend.Security.Domain.Models;
using SafePetBackend.Security.Domain.Repositories;
using SafePetBackend.Security.Domain.Services;
using SafePetBackend.Security.Domain.Services.Communication;
using SafePetBackend.Security.Exceptions;
using SafePetBackend.Shared.Domain.Repositories;
using BCryptNet = BCrypt.Net.BCrypt;

namespace SafePetBackend.Security.Services;

public class UserService : IUserService
{

    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    private readonly IJwtHandler _jwtHandler;
    private readonly IMapper _mapper;

    public UserService(IJwtHandler jwtHandler,
        IMapper mapper, IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _jwtHandler = jwtHandler;
        _mapper = mapper;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
    {
        var user = await _userRepository.FindByEmailAsync(request.Email);
        Console.WriteLine($"Request: {request.Email}, {request.Password}");
        Console.WriteLine($"User: {user.Id}, {user.Name}, {user.Email}, {user.Birthday}, {user.Phone}, {user.Password}");


        // validate
        if (user == null || !BCryptNet.Verify(request.Password, user.Password))
        {
            Console.WriteLine("Authentication Error");
            throw new AppException("Username or password is incorrect");
        }

        Console.WriteLine("Authentication successful. About to generate token");
        // authentication successful
        var response = _mapper.Map<AuthenticateResponse>(user);
        Console.WriteLine($"Response: {response.Id}, {response.Name}, {response.Email}");
        response.Token = _jwtHandler.GenerateToken(user);
        Console.WriteLine($"Generated token is {response.Token}");
        return response;
    }

    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _userRepository.ListAsync();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        var user = await _userRepository.FindByIdAsync(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }
    
    public async Task<User> GetByEmailAsync(string email)
    {
        var user = await _userRepository.FindByEmailAsync(email);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }


    public async Task RegisterAsync(RegisterRequest request)
    {
        // validate
        if (_userRepository.ExistsByEmail(request.Email))
            throw new AppException("Email '" + request.Email + "' is already taken");

        // map model to new user object
        var user = _mapper.Map<User>(request);

        // hash password
        //user.Password = BCryptNet.HashPassword(request.Password);

        // save user
        try
        {
            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while saving the user: {e.Message}");
        }
    }

    public async Task UpdateAsync(int id, UpdateRequest request)
    {
        var user = GetById(id);

        // Validate
        if (_userRepository.ExistsByEmail(request.Email))
            throw new AppException("Email '" + request.Email + "' is already taken");

        // Hash password if it was entered
        if (!string.IsNullOrEmpty(request.Password))
            user.Password = BCryptNet.HashPassword(request.Password);

        // Copy model to user and save
        _mapper.Map(request, user);
        try
        {
            _userRepository.Update(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while updating the user: {e.Message}");
        }
    }

    public async Task DeleteAsync(int id)
    {
        var user = GetById(id);

        try
        {
            _userRepository.Remove(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while deleting the user: {e.Message}");
        }
    }

    // helper methods

    private User GetById(int id)
    {
        var user = _userRepository.FindById(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }

    private User GetByEmail(string email)
    {
        var user = _userRepository.FindByEmail(email);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }
}
