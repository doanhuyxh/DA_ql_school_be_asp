using Microsoft.EntityFrameworkCore;
using BeApi.Models;
namespace BeApi.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Users> Users { get; set; }
    public DbSet<FileImport> FileImport { get; set; }
    public DbSet<Admission> Admission { get; set; }
    public DbSet<Faculty> Faculty { get; set; }
    public DbSet<Major> Major { get; set; }
    public DbSet<StudentClass> StudentClass { get; set; }
    public DbSet<StudentProfile> StudentProfile { get; set; }
    
}