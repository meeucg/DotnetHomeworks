using DZ1.Interfaces;
using DZ1.Models;
using DZ1.Services;
using Microsoft.AspNetCore.Mvc;

namespace DZ1.Endpoints;

public static class UserEndpointsExtension
{
    public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        var usersGroup = app.MapGroup("/users");

        usersGroup.MapPost("/create", async ([FromBody] UserCreateRequest userCreateRequest, IUserService userService) =>
            await userService.AddUserAsync(
                userCreateRequest.Username, 
                userCreateRequest.Password)
        );

        usersGroup.MapPost("/remove",
            async ([FromBody] UserRemoveRequest userRemoveRequest, IUserService userService) => 
            await userService.RemoveUserAsync(
                userRemoveRequest.Username, 
                userRemoveRequest.Password));

        usersGroup.MapPost("/edit", 
            async ([FromBody] UserUpdateRequest userEditRequest, IUserService userService) => 
            await userService.UpdateUserAsync(
                userEditRequest.OldUsername, 
                userEditRequest.OldPassword, 
                userEditRequest.NewUsername, 
                userEditRequest.NewPassword));
        
        return usersGroup;
    }
}