using DZ1.Database;
using DZ1.Entities;
using DZ1.Interfaces;

namespace DZ1.Services.Repositories;

public class UserRepository(Db db) : IUserRepository
{
    public async Task<User?> Get(string key)
    {
        return db.Users.FirstOrDefault(u => u.Username == key);
    }

    public async Task<User> Add(User entity)
    {
        db.Users.Add(entity);
        return entity;
    }

    public async Task<bool> Remove(string key)
    {
        var res = db.Users.RemoveAll(u => u.Username == key);
        return res != 0; 
    }

    public async Task<User?> Update(string username, User entity)
    {
        var user = db.Users.FindIndex(u => u.Username == username);
        if (user == -1) return null;
        
        if(entity.Username != null) db.Users[user].Username = entity.Username;
        if(entity.Password != null) db.Users[user].Password = entity.Password;
        return db.Users[user];

    }

    public async Task<bool> Exists(string key)
    {
        return db.Users.Any(u => u.Username == key);
    }
}