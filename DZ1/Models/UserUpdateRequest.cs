namespace DZ1.Models;

public record UserUpdateRequest(
    string OldUsername, 
    string OldPassword, 
    string? NewUsername = null, 
    string? NewPassword = null);