using System.ComponentModel.DataAnnotations;

namespace BeApi.Models;

public class StudentClass
{
    [Key]
    public int Id { get; set; }
    public string? ClassName { get; set; }
    public int MajorId { get; set; }
    public int FacultyId { get; set; }
    public int Year { get; set; }
    public virtual List<StudentProfile> StudentProfiles { get; set; }
}