namespace BeApi.Controller;
using Microsoft.AspNetCore.Mvc;
using BeApi.Data;
using BeApi.Services;
using BeApi.ViewModels;
using System.Security.Claims;

[Route("api/v1/auth")]
[ApiController]
public class AuthController:ControllerBase {
    private readonly ICommon _common;
    private readonly ApplicationDbContext _context;
    public AuthController(ICommon common, ApplicationDbContext context)
    {
        this._common = common;
        this._context = context;
    }

    [HttpPost("login")]
    public IActionResult Register([FromBody] LoginVM loginVM)
    {
        
        var user = _context.Users.FirstOrDefault(x => x.Email == loginVM.Email);
        if (user == null)
        {
            return Ok(new ResponeDataViewModel(ResponseStatusCode.NotFound, "User not found"));
        }

        string passwordHash = _common.HashPasswordWithMD5(loginVM.Password??"");

        if (user.Password != passwordHash)
        {
            return Ok(new ResponeDataViewModel(ResponseStatusCode.BadRequest, "Password is incorrect"));
        }
        
        var accessToken = _common.GenerateToken(user.Id, user.Role??"", 180);
		var refreshTokenToken = _common.GenerateToken(user.Id, user.Role??"", 10080);

        return Ok(new ResponeDataViewModel(ResponseStatusCode.Success, new
		{
			accessToken,
			refreshToken = refreshTokenToken,
		}));
    }

    [HttpPost("refresh-token")]
    public IActionResult RefreshToken([FromBody] RefreshTokenVM refreshTokenVM)
    {
        var principal = _common.ValidateToken(refreshTokenVM.RefreshToken??"");
        if (principal == null)
        {
            return Ok(new ResponeDataViewModel(ResponseStatusCode.Unauthorized, "Unauthorized access"));
        }

        var userId = int.Parse(principal.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
        var user = _context.Users.FirstOrDefault(x => x.Id == userId);
        if (user == null)
        {
            return Ok(new ResponeDataViewModel(ResponseStatusCode.NotFound, "User not found"));
        }

        var accessToken = _common.GenerateToken(user.Id, user.Role??"", 180);
        var refreshTokenToken = _common.GenerateToken(user.Id, user.Role??"", 10080);

        return Ok(new ResponeDataViewModel(ResponseStatusCode.Success, new
        {
            accessToken,
            refreshToken = refreshTokenToken,
        }));
    }

    [HttpGet("send-mail-reset-password")]
    public IActionResult SendMailResetPassword([FromQuery] string email)
    {
        var user = _context.Users.FirstOrDefault(x => x.Email == email);
        if (user == null)
        {
            return Ok(new ResponeDataViewModel(ResponseStatusCode.NotFound, "User not found"));
        }

        string passwordHash = _common.HashPasswordWithMD5("user123456@@");

        user.Password = passwordHash;
        _context.Update(user);
        _context.SaveChanges();

        // Send mail reset password
        bool sendMailStatus = _common.SendMail(email, "Reset password", $"Your new password is: user123456@@");
        if (!sendMailStatus)
        {
            return Ok(new ResponeDataViewModel(ResponseStatusCode.InternalServerError, "Send mail reset password fail"));
        }
        return Ok(new ResponeDataViewModel(ResponseStatusCode.Success, "Send mail reset password success"));
    }

}