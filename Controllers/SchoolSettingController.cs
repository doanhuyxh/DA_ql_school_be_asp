using BeApi.Data;
using BeApi.Models;
using BeApi.Services;
using BeApi.ViewModels;
using BeApi.ViewModels.FacultyViewModel;
using BeApi.ViewModels.SchoolSettingViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeApi.Controllers;

[Authorize]
[Route("api/v1/school-setting")]
[ApiController]
public class SchoolSettingController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ICommon _common;
    
    public SchoolSettingController(ApplicationDbContext context, ICommon common)
    {
        _context = context;
        _common = common;
    }
    
    [HttpGet("get-faculty")]
    public IActionResult GetFaculty([FromQuery] int page = 0, [FromQuery] int paeSize = 10, [FromQuery] string search = "", [FromQuery] int majorId = 0)
    {
        var query = _context.Faculty.AsQueryable();
        
        if (majorId != 0)
        {
            query = query.Where(x => x.MajorId == majorId);
        }
        
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(x => x.FacultyName.Contains(search));
        }
        
        var faculty = query.Skip(page * paeSize).Take(paeSize).ToList();
        
        return Ok(new ResponeDataViewModel(ResponseStatusCode.Success, faculty));
    }
    
    
    [HttpGet("get-faculty-by-id")]
    public IActionResult GetFacultyById([FromQuery] int id)
    {
        var faculty = _context.Faculty.FirstOrDefault(x => x.Id == id);
        if (faculty == null)
        {
            return Ok(new ResponeDataViewModel(ResponseStatusCode.NotFound, "Faculty not found"));
        }
        return Ok(new ResponeDataViewModel(ResponseStatusCode.Success, faculty));
    }
    
    [HttpPost("create-faculty")]
    public IActionResult CreateFaculty([FromBody] FacultyViewModel vm)
    {
        var faculty = new Faculty();
        faculty.FacultyName = vm.FacultyName;
        faculty.MajorId = vm.MajorId;
        _context.Faculty.Add(faculty);
        _context.SaveChanges();
        return Ok(new ResponeDataViewModel(ResponseStatusCode.Success));
    }

    [HttpPost("update-faculty")]
    public IActionResult UpdateFaculty([FromBody] FacultyViewModel vm)
    {
        var facultyUpdate = _context.Faculty.FirstOrDefault(x => x.Id == vm.Id);
        if (facultyUpdate == null)
        {
            return Ok(new ResponeDataViewModel(ResponseStatusCode.NotFound, "Faculty not found"));
        }

        facultyUpdate.FacultyName = vm.FacultyName;
        _context.Update(facultyUpdate);
        _context.SaveChanges();
        return Ok(new ResponeDataViewModel(ResponseStatusCode.Success));
    }
    
    [HttpGet("delete-faculty")]
    public IActionResult DeleteFaculty([FromQuery] int id)
    {
        var faculty = _context.Faculty.FirstOrDefault(x => x.Id == id);
        if (faculty == null)
        {
            return Ok(new ResponeDataViewModel(ResponseStatusCode.NotFound, "Faculty not found"));
        }
        _context.Remove(faculty);
        _context.SaveChanges();
        return Ok(new ResponeDataViewModel(ResponseStatusCode.Success));
    }
    
    [HttpGet("get-major")]
    public IActionResult GetMajor([FromQuery] int page = 0, [FromQuery] int paeSize = 10, [FromQuery] string search = "")
    {
        var query = _context.Major.AsQueryable();
        
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(x => x.MajorName.Contains(search));
        }
        
        var major = query.Skip(page * paeSize).Take(paeSize).ToList();
        
        return Ok(new ResponeDataViewModel(ResponseStatusCode.Success, major));
    }
    
    [HttpGet("get-major-by-id")]
    public IActionResult GetMajorById([FromQuery] int id)
    {
        var major = _context.Major.FirstOrDefault(x => x.Id == id);
        if (major == null)
        {
            return Ok(new ResponeDataViewModel(ResponseStatusCode.NotFound, "Major not found"));
        }
        return Ok(new ResponeDataViewModel(ResponseStatusCode.Success, major));
    }

    [HttpPost("create-major")]
    public IActionResult CreateMajor([FromBody] MajorViewModel vm)
    {
        var major = new Major();
        major.MajorName = vm.MajorName;
        _context.Add(major);
        _context.SaveChanges();
        return Ok(new ResponeDataViewModel(ResponseStatusCode.Success));
    }
    
    [HttpPost("update-major")]
    public IActionResult UpdateMajor([FromBody] MajorViewModel vm)
    {
        
        
        var majorUpdate = _context.Major.FirstOrDefault(x => x.Id == vm.Id);
        if (majorUpdate == null)
        {
            return Ok(new ResponeDataViewModel(ResponseStatusCode.NotFound, "Major not found"));
        }

        majorUpdate.MajorName = vm.MajorName;
        _context.Update(majorUpdate);
        _context.SaveChanges();
        return Ok(new ResponeDataViewModel(ResponseStatusCode.Success));
    }
    
    [HttpGet("delete-major")]
    public IActionResult DeleteMajor([FromQuery] int id)
    {
        var major = _context.Major.FirstOrDefault(x => x.Id == id);
        if (major == null)
        {
            return Ok(new ResponeDataViewModel(ResponseStatusCode.NotFound, "Major not found"));
        }
        _context.Remove(major);
        _context.SaveChanges();
        return Ok(new ResponeDataViewModel(ResponseStatusCode.Success));
    }
    
    [HttpGet("get-class")]
    public IActionResult GetClass([FromQuery] int page = 0, [FromQuery] int paeSize = 10, [FromQuery] string search = "", [FromQuery] int majorId = 0, [FromQuery] int facultyId = 0)
    {
        var query = _context.StudentClass.AsQueryable();
        
        if (majorId != 0)
        {
            query = query.Where(x => x.MajorId == majorId);
        }
        
        if (facultyId != 0)
        {
            query = query.Where(x => x.FacultyId == facultyId);
        }
        
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(x => x.ClassName.Contains(search));
        }
        
        var classData = query.Skip(page * paeSize).Take(paeSize).ToList();
        
        return Ok(new ResponeDataViewModel(ResponseStatusCode.Success, classData));
    }
    
    [HttpGet("get-class-by-id")]
    public IActionResult GetClassById([FromQuery] int id)
    {
        var classData = _context.StudentClass.FirstOrDefault(x => x.Id == id);
        if (classData == null)
        {
            return Ok(new ResponeDataViewModel(ResponseStatusCode.NotFound, "Class not found"));
        }
        return Ok(new ResponeDataViewModel(ResponseStatusCode.Success, classData));
    }
    
    [HttpPost("create-class")]
    public IActionResult CreateClass([FromBody] StudentClassViewModel classData)
    {
        _context.Add(classData);
        _context.SaveChanges();
        return Ok(new ResponeDataViewModel(ResponseStatusCode.Success));
    }
    
    [HttpPost("update-class")]
    public IActionResult UpdateClass([FromBody] StudentClassViewModel vm)
    {
        var classUpdate = _context.StudentClass.FirstOrDefault(x => x.Id == vm.Id);
        if (classUpdate == null)
        {
            return Ok(new ResponeDataViewModel(ResponseStatusCode.NotFound, "Class not found"));
        }

        classUpdate.ClassName = vm.ClassName;
        _context.Update(classUpdate);
        _context.SaveChanges();
        return Ok(new ResponeDataViewModel(ResponseStatusCode.Success));
    }
    
    [HttpGet("delete-class")]
    public IActionResult DeleteClass([FromQuery] int id)
    {
        var classData = _context.StudentClass.FirstOrDefault(x => x.Id == id);
        if (classData == null)
        {
            return Ok(new ResponeDataViewModel(ResponseStatusCode.NotFound, "Class not found"));
        }
        _context.Remove(classData);
        _context.SaveChanges();
        return Ok(new ResponeDataViewModel(ResponseStatusCode.Success));
    }
}