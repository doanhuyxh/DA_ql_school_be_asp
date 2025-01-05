using System.Security.Claims;

namespace BeApi.Services
{
    public interface ICommon
    {
        string GenerateToken(int userId, string role, int numberMinutesExpires);
        ClaimsPrincipal? ValidateToken(string token);
        string HashPasswordWithMD5(string password);
        bool SendMail(string to, string subject, string body);
        string GenerateRandomString(int length);
        string GenerateRandomNumber(int length);
        Task<string> PathFileUpload(IFormFile file);
    }
    
}