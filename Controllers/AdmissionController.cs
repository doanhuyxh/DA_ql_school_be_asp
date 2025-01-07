using BeApi.Data;
using BeApi.Services;
using BeApi.ViewModels;
using BeApi.ViewModels.AdmissionProfileViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeApi.Controllers
{
    [Route("api/v1/admission")]
    [Authorize]
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

        [HttpGet("get-admission-profile")]
        public IActionResult GetAdmissionProfile([FromQuery] int page = 1, [FromQuery] int pageSize = 20,
            [FromQuery] string status = "", [FromQuery] string search = "")
        {
            var query = _context.Admission.AsQueryable();

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
                query = query.Where(x =>
                    x.FirstName.Contains(search) || x.LastName.Contains(search) ||
                    x.RegistrationNumber.Contains(search) || x.StudentCode.Contains(search));
            }

            var admissionProfile =
                query.OrderByDescending(x => x.Id).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return Ok(new ResponeDataViewModel(ResponseStatusCode.Success, admissionProfile));
        }

        [HttpGet("get-admission-profile-by-id")]
        public IActionResult GetAdmissionProfileById([FromQuery] int id)
        {
            var admissionProfile = _context.Admission.FirstOrDefault(x => x.Id == id);
            if (admissionProfile == null)
            {
                return Ok(new ResponeDataViewModel(ResponseStatusCode.NotFound, "Admission profile not found"));
            }

            return Ok(new ResponeDataViewModel(ResponseStatusCode.Success, admissionProfile));
        }

        [HttpPost("create-admission-profile")]
        public async Task<IActionResult> CreateAdmissionProfile([FromBody] AdmissionViewModel admissionProfile)
        {
            if (admissionProfile.AvatarFile != null)
            {
                var avatar = await _common.PathFileUpload(admissionProfile.AvatarFile);
                admissionProfile.AvatarPath = avatar;
            }
            
            if (admissionProfile.BirthCertificateFile != null)
            {
                var cv = await _common.PathFileUpload(admissionProfile.BirthCertificateFile);
                admissionProfile.BirthCertificate = cv;
            }
            
            if (admissionProfile.CitizenIdentificationCardAfterFile != null)
            {
                var cv = await _common.PathFileUpload(admissionProfile.CitizenIdentificationCardAfterFile);
                admissionProfile.CitizenIdentificationCardAfterPath = cv;
            }
            
            _context.Add(admissionProfile);
            await _context.SaveChangesAsync();
            return Ok(new ResponeDataViewModel(ResponseStatusCode.Success));
        }
    }
}