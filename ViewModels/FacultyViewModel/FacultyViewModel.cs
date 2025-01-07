using BeApi.Models;

namespace BeApi.ViewModels.FacultyViewModel;

public class FacultyViewModel
{
    public int Id { get; set; }
    public string? FacultyName { get; set; }
    public int MajorId { get; set; }
    
    
    public static implicit operator Faculty(FacultyViewModel facultyViewModel)
    {
        return new Faculty
        {
            Id = facultyViewModel.Id,
            FacultyName = facultyViewModel.FacultyName,
            MajorId = facultyViewModel.MajorId
        };
    }
    
    public static implicit operator FacultyViewModel(Faculty faculty)
    {
        return new FacultyViewModel
        {
            Id = faculty.Id,
            FacultyName = faculty.FacultyName,
            MajorId = faculty.MajorId
        };
    }
}