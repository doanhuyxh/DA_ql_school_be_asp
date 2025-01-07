using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeApi.Models;

public class StudentProfile // Thông tin hồ sơn sinh viên
{
    [Key]
    public int Id { get; set; }
    public string? StudentCode { get; set; } // SBD
    public string? FirstName { set; get; }
    public string? LastName { set; get; }
    public string? DateOfBirth { set; get; } // ngày sinh
    public string? Avatar { set; get; }
    public string? Gender { set; get; }
    public string? CitizenIdentificationCard { set; get; } // số chứng minh nhân dân
    public string? PermanentAddress { set; get; } // địa chỉ thường trú
    public string? CurrentAddress { set; get; } // địa chỉ hiện tại
    public string? HealthInsuranceNumber { set; get; } // số bảo hiểm y tế
    public string? PhoneNumber { set; get; } // số điện thoại
    public int AdmissionYear { set; get; } // năm nhập học
    public int StudentClassId { set; get; } // lớp học
    public int  MajorId { set; get; } // chuyên ngành
    public int  FacultyId { set; get; } // khoa
    public int UserId { set; get; } // set userId
    
    [ForeignKey("UserId")]
    public virtual Users Users { get; set; }
    [ForeignKey("StudentClassId")]
    public virtual StudentClass StudentClass { get; set; }
    [ForeignKey("MajorId")]
    public virtual Major Major { get; set; }
    [ForeignKey("FacultyId")]
    public virtual Faculty Faculty { get; set; }
    
}