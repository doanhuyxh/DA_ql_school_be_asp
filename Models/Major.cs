using System.ComponentModel.DataAnnotations;

namespace BeApi.Models;

public class Major
{
    [Key]
    public int Id { get; set; }
    public string? MajorName { get; set; }
    public virtual List<StudentProfile> StudentProfiles { get; set; }
}