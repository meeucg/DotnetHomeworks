namespace DZ1.Interfaces;

public interface IUserService
{
    Task<IResult> AddUserAsync(string username, string password);
    Task<IResult> RemoveUserAsync(string username, string password);
    Task<IResult> UpdateUserAsync(string oldUsername, string oldPassword, string? newUsername, string? newPassword);
}