namespace BeApi.Controller;
using Microsoft.AspNetCore.Mvc;
using BeApi.Data;
using BeApi.Services;
using BeApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using BeApi.Models;

[Route("api/v1/user-manager")]
[ApiController]
[Authorize]
public class UserManagerController : ControllerBase
{
    private readonly ICommon _common;
    private readonly ApplicationDbContext _context;
    public UserManagerController(ICommon common, ApplicationDbContext context)
    {
        this._common = common;
        this._context = context;
    }

    [HttpPost("update-password")]
    public IActionResult UpdatePassword([FromBody] UpdatePasswordVM updatePasswordVM)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == updatePasswordVM.Id);
        if (user == null)
        {
            return Ok(new ResponeDataViewModel(ResponseStatusCode.NotFound, "User not found"));
        }

        string passwordHash = _common.HashPasswordWithMD5(updatePasswordVM.CurrentPassword ?? "");

        if (user.Password != passwordHash)
        {
            return Ok(new ResponeDataViewModel(ResponseStatusCode.BadRequest, "Current password is incorrect"));
        }

        passwordHash = _common.HashPasswordWithMD5(updatePasswordVM.NewPassword ?? "");

        user.Password = passwordHash;
        _context.Update(user);
        _context.SaveChanges();

        return Ok(new ResponeDataViewModel(ResponseStatusCode.Success, "Update password success"));
    }

    [HttpPost("update-profile")]
    public IActionResult UpdateProfile([FromBody] UserUpdateViewModel user)
    {
        var userUpdate = _context.Users.FirstOrDefault(x => x.Id == user.Id);
        if (userUpdate == null)
        {
            return Ok(new ResponeDataViewModel(ResponseStatusCode.NotFound, "User not found"));
        }

        userUpdate.FirstName = user.FirstName;
        userUpdate.LastName = user.LastName;
        userUpdate.Role = user.Role;
        _context.Update(userUpdate);
        _context.SaveChanges();

        return Ok(new ResponeDataViewModel(ResponseStatusCode.Success, "Update profile success"));
    }

    [HttpGet("get-profile")]
    public IActionResult GetProfile()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
        var user = _context.Users.FirstOrDefault(x => x.Id == int.Parse(userId));
        if (user == null)
        {
            return Ok(new ResponeDataViewModel(ResponseStatusCode.NotFound, "User not found"));
        }
        user.Password = "";
        return Ok(new ResponeDataViewModel(ResponseStatusCode.Success, user));
    }

    [Authorize(Roles = "admin")]
    [HttpGet("get-all-user-by-role")]
    public IActionResult GetAllUserByRole([FromQuery] string role="")
    {
        var query = _context.Users.AsQueryable();
        if (!string.IsNullOrEmpty(role))
        {
            query = query.Where(x => x.Role == role);
        }
        query = query.Where(x => x.Role != "admin");
        var users = query.ToList();
        return Ok(new ResponeDataViewModel(ResponseStatusCode.Success, users));
    }

    [Authorize(Roles="admin")]
    [HttpGet("delete-user-by-id")]
    public IActionResult DeleteUserById([FromQuery] int id)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == id);
        if (user == null)
        {
            return Ok(new ResponeDataViewModel(ResponseStatusCode.NotFound, "User not found"));
        }
        _context.Remove(user);
        _context.SaveChanges();
        return Ok(new ResponeDataViewModel(ResponseStatusCode.Success, "Delete user success"));
    }

    [Authorize(Roles="admin")]
    [HttpPost("create-user")]
    public IActionResult CreateUser([FromBody] UserCreateViewModel user)
    {
        var userCreate = new Users
        {
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Role = user.Role,
            Password = _common.HashPasswordWithMD5(user.Password ?? "")
        };
        _context.Add(userCreate);
        _context.SaveChanges();
        return Ok(new ResponeDataViewModel(ResponseStatusCode.Success, "Create user success"));
    }

}