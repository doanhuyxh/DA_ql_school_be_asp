using BeApi.Models;

namespace BeApi.ViewModels.AdmissionProfileViewModel
{
    public class AdmissionViewModel
    {
        public int Id { get; set; }
        public string? RegistrationNumber { get; set; }
        public string? AdmissionProfileCode { get; set; }
        public string? AvatarPath { get; set; }
        public string? FirstName { set; get; }
        public string? LastName { set; get; }
        public string? DateOfBirth { set; get; }
        public string? BirthCertificate { set; get; }
        public string? Gender { set; get; }
        public string? PlaceOfBirth { set; get; }
        public string? CitizenIdentificationCard { set; get; }
        public string? CitizenIdentificationCardBeforPath { set; get; }
        public string? CitizenIdentificationCardAfterPath { set; get; }
        public string? HealthInsuranceNumber { set; get; }
        public string? Email { set; get; }
        public string? PhoneNumber { set; get; }
        public bool IsSendMail { set; get; }
        public bool IsPayment { set; get; }
        public string? Class { set; get; } 
        public string? StudentCode { set; get; }
        public bool IsMatriculated { set; get; }
        
        public IFormFile? AvatarFile { set; get; }
        public IFormFile? BirthCertificateFile { set; get; }
        public IFormFile? CitizenIdentificationCardBeforFile { set; get; }
        public IFormFile? CitizenIdentificationCardAfterFile { set; get; }

        public static implicit operator Admission(AdmissionViewModel item)
        {
            return new Admission
            {
                Id = item.Id,
                RegistrationNumber = item.RegistrationNumber,
                AdmissionProfileCode = item.AdmissionProfileCode,
                AvatarPath = item.AvatarPath,
                FirstName = item.FirstName,
                LastName = item.LastName,
                DateOfBirth = item.DateOfBirth,
                BirthCertificatePath = item.BirthCertificate,
                Gender = item.Gender,
                PlaceOfBirth = item.PlaceOfBirth,
                CitizenIdentificationCard = item.CitizenIdentificationCard,
                CitizenIdentificationCardBeforPath = item.CitizenIdentificationCardBeforPath,
                CitizenIdentificationCardAfterPath = item.CitizenIdentificationCardAfterPath,
                HealthInsuranceNumber = item.HealthInsuranceNumber,
                Email = item.Email,
                PhoneNumber = item.PhoneNumber,
                IsSendMail = item.IsSendMail,
                IsPayment = item.IsPayment,
                Class = item.Class,
                StudentCode = item.StudentCode,
                IsMatriculated = item.IsMatriculated
            };
        }
    }
}
