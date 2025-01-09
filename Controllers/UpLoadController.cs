using BeApi.Data;
using BeApi.Models;
using BeApi.Services;
using BeApi.ViewModels;
using BeApi.ViewModels.FileImportViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BeApi.Controllers;

[Route("api/v1/upload")]
[ApiController]
public class UpLoadController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ICommon _common;
    
    public UpLoadController(ApplicationDbContext context, ICommon common)
    {
        _context = context;
        _common = common;
    }
    
    [HttpGet("get-file-import-by-type")]
    public IActionResult GetFileImportByType([FromQuery] string type ="")
    {
        var query = _context.FileImport.AsQueryable();
        if (!string.IsNullOrEmpty(type))
        {
            query = query.Where(x => x.Type == type);
        }
        var fileImport = query.OrderByDescending(i=>i.Id).ToList();
        return Ok(new ResponeDataViewModel(ResponseStatusCode.Success, fileImport));
    }
    
    [HttpGet("get-file-import-by-id")]
    public IActionResult GetFileImportById([FromQuery] int id)
    {
        var fileImport = _context.FileImport.FirstOrDefault(x => x.Id == id);
        if (fileImport == null)
        {
            return Ok(new ResponeDataViewModel(ResponseStatusCode.NotFound, "File not found"));
        }
        return Ok(new ResponeDataViewModel(ResponseStatusCode.Success, fileImport));
    }
    
    [HttpPost("create-upload-file-import")]
    public IActionResult CreateFileImport([FromBody] FileImport fileImport)
    {
        _context.Add(fileImport);
        _context.SaveChanges();
        return Ok(new ResponeDataViewModel(ResponseStatusCode.Success));
    }
    
    [HttpPost("upload-file")]
    public IActionResult UploadFile([FromForm] FileImportViewModel vm)
    {

        string path = _common.PathFileUpload(vm.File).Result;
        
        return Ok(new ResponeDataViewModel(ResponseStatusCode.Success, path));
    }
}