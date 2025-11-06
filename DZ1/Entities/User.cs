namespace DZ1.Entities;

public record User
{
    public required string? Username { get; set; }
    public required string? Password { get; set; }
}