using Microsoft.EntityFrameworkCore;
using StudentRegistration.Domain.Entities;

namespace StudentRegistration.Application.Data;

public interface IApplicationDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    DbSet<Student> Students { get; set; }
}