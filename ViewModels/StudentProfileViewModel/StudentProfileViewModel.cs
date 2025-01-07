using BeApi.Models;

namespace BeApi.ViewModels.StudentProfileViewModel;

public class StudentProfileViewModel
{
    public int Id { get; set; }
    public string? StudentCode { get; set; }
    public string? FirstName { set; get; }
    public string? LastName { set; get; }
    public string? DateOfBirth { set; get; }
    public string? Avatar { set; get; }
    public string? Gender { set; get; }
    public string? CitizenIdentificationCard { set; get; }
    public string? PermanentAddress { set; get; }
    public string? CurrentAddress { set; get; }
    public string? HealthInsuranceNumber { set; get; }
    public string? PhoneNumber { set; get; }
    public int AdmissionYear { set; get; }
    public int StudentClassId { set; get; }
    public int  MajorId { set; get; }
    public int  FacultyId { set; get; }
    public int UserId { set; get; }
    
    public IFormFile? AvatarFile { set; get; }

    public static implicit operator StudentProfileViewModel(StudentProfile item)
    {
        return new StudentProfileViewModel
        {
            Id = item.Id,
            StudentCode = item.StudentCode,
            FirstName = item.FirstName,
            LastName = item.LastName,
            DateOfBirth = item.DateOfBirth,
            Avatar = item.Avatar,
            Gender = item.Gender,
            CitizenIdentificationCard = item.CitizenIdentificationCard,
            PermanentAddress = item.PermanentAddress,
            CurrentAddress = item.CurrentAddress,
            HealthInsuranceNumber = item.HealthInsuranceNumber,
            PhoneNumber = item.PhoneNumber,
            AdmissionYear = item.AdmissionYear,
            StudentClassId = item.StudentClassId,
            MajorId = item.MajorId,
            FacultyId = item.FacultyId,
            UserId = item.UserId
        };
    }

    public static implicit operator StudentProfile(StudentProfileViewModel item)
    {
        return new StudentProfile
        {
            Id = item.Id,
            StudentCode = item.StudentCode,
            FirstName = item.FirstName,
            LastName = item.LastName,
            DateOfBirth = item.DateOfBirth,
            Avatar = item.Avatar,
            Gender = item.Gender,
            CitizenIdentificationCard = item.CitizenIdentificationCard,
            PermanentAddress = item.PermanentAddress,
            CurrentAddress = item.CurrentAddress,
            HealthInsuranceNumber = item.HealthInsuranceNumber,
            PhoneNumber = item.PhoneNumber,
            AdmissionYear = item.AdmissionYear,
            StudentClassId = item.StudentClassId,
            MajorId = item.MajorId,
            FacultyId = item.FacultyId,
            UserId = item.UserId
        };
    }
}