using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace BeApi.Models
{
    public class Admission // tuyển sinh
    {
        [Key]
        public int Id { get; set; }
        public string? RegistrationNumber { get; set; } // SBD
        public string? AdmissionProfileCode { get; set; } // mã hồ sơ
        public string? AvatarPath { get; set; } // ảnh đại diện
        public string? FirstName { set; get; }
        public string? LastName { set; get; }
        public string? DateOfBirth { set; get; }
        public string? BirthCertificatePath { set; get; } // ảnh giấy khai sinh
        public string? Gender { set; get; }
        public string? PlaceOfBirth { set; get; }
        public string? CitizenIdentificationCard { set; get; } // số chứng minh nhân dân
        public string? CitizenIdentificationCardBeforPath { set; get; } // ảnh chứng minh nhân dân mặt trước
        public string? CitizenIdentificationCardAfterPath { set; get; } // ảnh chứng minh nhân dân mặt sau
        public string? PermanentAddress { set; get; } // địa chỉ thường trú
        public string? CurrentAddress { set; get; } // địa chỉ hiện tại
        public string? HealthInsuranceNumber { set; get; } // số bảo hiểm y tế
        public string? Email { set; get; }
        public string? PhoneNumber { set; get; }
        public bool IsSendMail { set; get; } // đã gửi mail trúng tuyển
        public bool IsMatriculated { set; get; } // đã trúng tuyển
    }
}
