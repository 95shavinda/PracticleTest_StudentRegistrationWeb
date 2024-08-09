using Microsoft.EntityFrameworkCore;
using StudentRegistration.Application.Data;
using StudentRegistration.Domain.Entities;

namespace StudentRegistration.Infrastructure;

public class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options
) : DbContext(options), IApplicationDbContext
{
    public DbSet<Student> Students { get; set; } = default!;
}