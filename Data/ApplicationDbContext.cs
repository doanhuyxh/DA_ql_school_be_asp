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
    public DbSet<AdmissionProfile> AdmissionProfile { get; set; }
}