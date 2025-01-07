using BeApi.Models;

namespace BeApi.ViewModels;

public class StudentClassViewModel
{
    public int Id { get; set; }
    public int MajorId { get; set; }
    public int FacultyId { get; set; }
    public int Year { get; set; }
    public string? ClassName { get; set; }
    
    public static implicit operator StudentClass(StudentClassViewModel studentClassViewModel)
    {
        return new StudentClass
        {
            Id = studentClassViewModel.Id,
            MajorId = studentClassViewModel.MajorId,
            FacultyId = studentClassViewModel.FacultyId,
            Year = studentClassViewModel.Year,
            ClassName = studentClassViewModel.ClassName
        };
    }
    
    public static implicit operator StudentClassViewModel(StudentClass studentClass)
    {
        return new StudentClassViewModel
        {
            Id = studentClass.Id,
            MajorId = studentClass.MajorId,
            FacultyId = studentClass.FacultyId,
            Year = studentClass.Year,
            ClassName = studentClass.ClassName
        };
    }
}