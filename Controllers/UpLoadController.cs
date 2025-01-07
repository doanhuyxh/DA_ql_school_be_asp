using BeApi.Data;
using BeApi.Models;
using BeApi.Services;
using BeApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BeApi.Controllers;

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
    public IActionResult GetFileImportByType([FromQuery] string type)
    {
        var fileImport = _context.FileImport.Where(x => x.Type == type).ToList();
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
}