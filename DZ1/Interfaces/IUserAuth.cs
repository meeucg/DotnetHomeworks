namespace DZ1.Interfaces;

public interface IUserAuth
{ 
    Task<bool> CheckPassword(string username, string password);
}