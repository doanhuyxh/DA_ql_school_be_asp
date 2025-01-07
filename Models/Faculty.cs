using System.ComponentModel.DataAnnotations;

namespace BeApi.Models;

public class Faculty
{
    [Key]
    public int Id { get; set; }
    public string? FacultyName { get; set; }
    public int MajorId { get; set; }
    
    public virtual List<StudentProfile> StudentProfiles { get; set; }
}