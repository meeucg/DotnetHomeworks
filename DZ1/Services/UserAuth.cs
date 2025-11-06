using DZ1.Interfaces;

namespace DZ1.Services;

public class UserAuth(IUserRepository userRepo) : IUserAuth
{
    public async Task<bool> CheckPassword(string username, string password)
    {
        var user = await userRepo.Get(username);
        if(user == null) return false;
        return user.Password == password;
    }
}