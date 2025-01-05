using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace BeApi.Models
{
    public class AdmissionProfile // hồ sơ
    {
        [Key]
        public int Id { get; set; }
        public string? RegistrationNumber { get; set; } // SBD
        public string? AdmissionProfileCode { get; set; } // mã hồ sơ
        public string? FirstName { set; get; }
        public string? LastName { set; get; }
        public string? DateOfBirth { set; get; }
        public string? Gender { set; get; }
        public string? PlaceOfBirth { set; get; }
        public string? CitizenIdentificationCard { set; get; } // số chứng minh nhân dân
        public string? PermanentAddress { set; get; } // địa chỉ thường trú
        public string? CurrentAddress { set; get; } // địa chỉ hiện tại
        public string? HealthInsuranceNumber { set; get; } // số bảo hiểm y tế
        public string? Email { set; get; }
        public string? PhoneNumber { set; get; }
        public bool IsSendMail { set; get; } // đã gửi mail
        public bool IsPayment { set; get; } // đã thanh toán
        public string? Class { set; get; } // lớp
        public string? StudentCode { set; get; } // mã sinh viên
        public bool IsMatriculated { set; get; } // đã trúng tuyển


    }
}
