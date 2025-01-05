using System.ComponentModel.DataAnnotations;

namespace BeApi.Models
{
    public class FileImport
    {
        [Key]
        public int Id { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public int NumberOfRecords { get; set; }
        public int NumberOfFalseRecords { get; set; }
        public string? Type { get; set; }
    }
}
