using BeApi.Data;
using BeApi.Models;
using BeApi.Services;
using BeApi.ViewModels;
using BeApi.ViewModels.StudentProfileViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeApi.Controllers;

[Authorize]
[Route("api/v1/student")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ICommon _common;
    
    public StudentController(ApplicationDbContext context, ICommon common)
    {
        _context = context;
        _common = common;
    }
    
    [HttpGet("get-student-profile")]
    public IActionResult GetStudentProfile()
    {
        var studentProfile = _context.StudentProfile.ToList();
        return Ok(new ResponeDataViewModel(ResponseStatusCode.Success, studentProfile));
    }
    
    [HttpGet("get-student-profile-by-id")]
    public IActionResult GetStudentProfileById([FromQuery] int id)
    {
        var studentProfile = _context.StudentProfile.FirstOrDefault(x => x.Id == id);
        if (studentProfile == null)
        {
            return Ok(new ResponeDataViewModel(ResponseStatusCode.NotFound, "Student not found"));
        }
        return Ok(new ResponeDataViewModel(ResponseStatusCode.Success, studentProfile));
    }
    
    [HttpPost("create-student-profile")]
    public async Task<IActionResult> CreateStudentProfile([FromBody] StudentProfileViewModel studentProfile)
    {
        
        if(studentProfile.AvatarFile != null)
        {
            var avatar = await _common.PathFileUpload(studentProfile.AvatarFile);
            studentProfile.Avatar = avatar;
        }
        
        _context.Add(studentProfile);
        await _context.SaveChangesAsync();
        return Ok(new ResponeDataViewModel(ResponseStatusCode.Success));
    }

    [HttpPost("update-student-profile")]
    public async Task<IActionResult> UpdateStudentProfile([FromBody] StudentProfileViewModel studentProfile)
    {
        var studentProfileUpdate = _context.StudentProfile.FirstOrDefault(x => x.Id == studentProfile.Id);
        if (studentProfileUpdate == null)
        {
            return Ok(new ResponeDataViewModel(ResponseStatusCode.NotFound, "Student not found"));
        }
        if(studentProfile.AvatarFile != null)
        {
            var avatar = await _common.PathFileUpload(studentProfile.AvatarFile);
            studentProfile.Avatar = avatar;
        }

        studentProfileUpdate = studentProfile;
        _context.Update(studentProfileUpdate);
        _context.SaveChanges();
        return Ok(new ResponeDataViewModel(ResponseStatusCode.Success));
    }
}