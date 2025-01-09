using BeApi.Data;
using BeApi.Models;
using BeApi.Services;
using BeApi.ViewModels;
using BeApi.ViewModels.StudentProfileViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public IActionResult GetStudentProfile([FromQuery] int page = 1, [FromQuery] int pageSize = 100, [FromQuery] string search="")
    {
        var query = _context.StudentProfile
            .AsQueryable();

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(i=>i.FirstName.Contains(search) || i.LastName.Contains(search) || i.StudentCode.Contains(search));
        }
        
        var studentProfile =query.Skip((page-1)*pageSize).Take(pageSize).ToList();
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
    
    [HttpGet("get-student-profile-by-userId")]
    public IActionResult GetStudentProfileByUserId([FromQuery] int id)
    {
        var studentProfile = _context.StudentProfile.FirstOrDefault(x => x.UserId == id);
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

    [HttpGet("create-student-profile-by-admission-card-id")]
    public IActionResult CreateStudentProfileByAdmissionCardId([FromQuery] string admissionCardId)
    {
        var admission = _context.Admission.FirstOrDefault(x => x.CitizenIdentificationCard == admissionCardId);
        if (admission == null)
        {
            return Ok(new ResponeDataViewModel(ResponseStatusCode.NotFound, "Admission not found"));
        }
        
        
        var check_student = _context.StudentProfile.FirstOrDefault(x => x.CitizenIdentificationCard == admission.CitizenIdentificationCard);
        
        if (check_student != null)
        {
            return Ok(new ResponeDataViewModel(ResponseStatusCode.BadRequest, "Student already exists"));
        }
        
        
        var student_acc = new Users
        {
            Email = admission.Email,
            Password = _common.HashPasswordWithMD5("123456"),
            Role = "student"
        };
        
        _context.Add(student_acc);
        _context.SaveChanges();
        
        var studentProfile = new StudentProfile
        {
            StudentCode = _common.GenerateRandomNumber(8),
            FirstName = admission.FirstName,
            LastName = admission.LastName,
            DateOfBirth = admission.DateOfBirth,
            Avatar = admission.AvatarPath,
            Gender = admission.Gender,
            CitizenIdentificationCard = admission.CitizenIdentificationCard,
            PermanentAddress = admission.PermanentAddress,
            CurrentAddress = admission.CurrentAddress,
            HealthInsuranceNumber = admission.HealthInsuranceNumber,
            PhoneNumber = admission.PhoneNumber,
            AdmissionYear = DateTime.Now.Year,
            StudentClassId = 1,
            MajorId =27,
            FacultyId = 61,
            UserId = student_acc.Id
        };
        
        _context.Add(studentProfile);

        admission.IsMatriculated = true;
        _context.Update(admission);
        _context.SaveChanges();
        return Ok(new ResponeDataViewModel(ResponseStatusCode.Success));
        
    }

    [HttpPost("update-student-profile")]
    public async Task<IActionResult> UpdateStudentProfile([FromForm] StudentProfileViewModel studentProfile)
    {
        var studentProfileUpdate = _context.StudentProfile.AsNoTracking().FirstOrDefault(x => x.Id == studentProfile.Id);
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
        await _context.SaveChangesAsync();
        return Ok(new ResponeDataViewModel(ResponseStatusCode.Success));
    }
    
    [HttpGet("delete-student-profile")]
    public IActionResult DeleteStudentProfile([FromQuery] int id)
    {
        var studentProfile = _context.StudentProfile.FirstOrDefault(x => x.Id == id);
        if (studentProfile == null)
        {
            return Ok(new ResponeDataViewModel(ResponseStatusCode.NotFound, "Student not found"));
        }
        
        var user = _context.Users.FirstOrDefault(x => x.Id == studentProfile.UserId);
        if (user != null)
        {
            _context.Remove(user);
        }
        
        _context.Remove(studentProfile);
        _context.SaveChanges();
        return Ok(new ResponeDataViewModel(ResponseStatusCode.Success));
    }
}