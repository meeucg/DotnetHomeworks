using DZ1.Entities;
using DZ1.Interfaces;

namespace DZ1.Services;

public class UserService(IUserRepository userRepo, IUserAuth userAuth) : IUserService
{
    public async Task<IResult> AddUserAsync(string username, string password)
    {
        var exists = await userRepo.Exists(username);
        
        if(exists) return Results.ValidationProblem(
            new Dictionary<string, string[]>
        {
            ["username"] = [ $"Username {username} already exists." ],
        });
        
        await userRepo.Add(new User{ Username = username, Password = password } );
        return Results.Created();
    }

    public async Task<IResult> UpdateUserAsync(
        string oldUsername, string oldPassword, string? newUsername = null, string? newPassword = null)
    {
        if(!await userAuth.CheckPassword(oldUsername, oldPassword))
            return Results.Unauthorized();
        
        return 
            await userRepo.Update(oldUsername, new User { Username = newUsername, Password = newPassword }) != null 
                ? Results.Ok() : Results.NotFound($"User with username {oldUsername} doesn't exist");
    }

    public async Task<IResult> RemoveUserAsync(string username, string password)
    {
        var exists = await userRepo.Exists(username);
        if(!exists) return Results.NotFound($"User with username {username} doesn't exist");
        await userRepo.Remove(username);
        return Results.Ok();
    }
}