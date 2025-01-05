using BeApi.Data;
using BeApi.Models;
using BeApi.Services;
using BeApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeApi.Controllers
{
    [Route("api/v1/admission")]
    [ApiController]
    public class AdmissionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICommon _common;
        public AdmissionController(ApplicationDbContext context, ICommon common)
        {
            _context = context;
            _common = common;
        }

        #region file import_chung tuyển

        [HttpGet("get-file-import-admission")]
        public IActionResult GetFileImportAdmission()
        {
            var fileImport = _context.FileImport.Where(x => x.Type == "Admission").ToList();
            return Ok(new ResponeDataViewModel(ResponseStatusCode.Success, fileImport));
        }

        [HttpGet("delete-admission-import-file")]
        public IActionResult DeleteAdmissionImportFile([FromQuery]int id)
        {
            var fileImport = _context.FileImport.FirstOrDefault(x => x.Id == id);
            if (fileImport == null)
            {
                return Ok(new ResponeDataViewModel(ResponseStatusCode.NotFound, "File not found"));
            }
            _context.Remove(fileImport);
            _context.SaveChanges();
            return Ok(new ResponeDataViewModel(ResponseStatusCode.Success));
        }


        [HttpPost("upload-file-import-admission")]
        public async Task<IActionResult> UploadFileImportAdmission([FromForm] FileUpload vm)
        {
            var pathFile = await _common.PathFileUpload(vm.File);
            _context.Add(new FileImport
            {
                FileName = vm.File.FileName,
                FilePath = pathFile,
                Type = "Admission",
                NumberOfRecords = 0,
                NumberOfFalseRecords = 0
            });
            _context.SaveChanges();

            return Ok(new ResponeDataViewModel(ResponseStatusCode.Success));
        }

        #endregion

        #region xỷ lý chúng tuyển

        [HttpGet("get-admission-profile")]
        public IActionResult GetAdmissionProfile([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] string status = "", [FromQuery] string search="")
        {
            var query = _context.AdmissionProfile.AsQueryable();

            if (!string.IsNullOrEmpty(status))
            {
                switch (status)
                {
                    case "isSendMail":
                        query = query.Where(x => x.IsSendMail == true);
                        break;
                    case "isPayment":
                        query = query.Where(x => x.IsPayment == true);
                        break;
                    case "isMatriculated":
                        query = query.Where(x => x.IsMatriculated == true);
                        break;
                    }
                }


            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.FirstName.Contains(search) || x.LastName.Contains(search) || x.RegistrationNumber.Contains(search) || x.StudentCode.Contains(search));
            }

            var admissionProfile = query.OrderByDescending(x => x.Id).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return Ok(new ResponeDataViewModel(ResponseStatusCode.Success, admissionProfile));
        }

        [HttpGet("get-admission-profile-by-id")]
        public IActionResult GetAdmissionProfileById([FromQuery] int id)
        {
            var admissionProfile = _context.AdmissionProfile.FirstOrDefault(x => x.Id == id);
            if (admissionProfile == null)
            {
                return Ok(new ResponeDataViewModel(ResponseStatusCode.NotFound, "Admission profile not found"));
            }
            return Ok(new ResponeDataViewModel(ResponseStatusCode.Success, admissionProfile));
        }

        [HttpPost("create-admission-profile")]
        public IActionResult CreateAdmissionProfile([FromBody] AdmissionProfile admissionProfile)
        {
            _context.Add(admissionProfile);
            _context.SaveChanges();
            return Ok(new ResponeDataViewModel(ResponseStatusCode.Success));
        }

        #endregion




    }
}
