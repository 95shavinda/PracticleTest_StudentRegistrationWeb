using Microsoft.EntityFrameworkCore;
using SharedKernel;
using StudentRegistration.Application.Core;
using StudentRegistration.Application.Data;
using StudentRegistration.Application.Requests;
using StudentRegistration.Application.Responses;
using StudentRegistration.Domain.Entities;

namespace StudentRegistration.Application.Services;

public class StudentService(
    IApplicationDbContext context
) : IStudentService
{
    private readonly IApplicationDbContext _context = context;

    public async Task<Result<IEnumerable<StudentGetResponse>>> GetAsync()
    {
        var students = await _context.Students
            .AsNoTracking()
            .Select(student => StudentGetResponse.FromEntity(student))
            .ToListAsync();

        return Result.Ok<IEnumerable<StudentGetResponse>>(students);
    }

    public async Task<Result<StudentGetResponse>> GetAsync(int id)
    {
        var student = await _context.Students
            .AsNoTracking()
            .Where(student => student.Id == id)
            .Select(student => StudentGetResponse.FromEntity(student))
            .FirstOrDefaultAsync();

        if (student is null)
            return Result.Fail<StudentGetResponse>("Student not found");

        return Result.Ok(student);
    }

    public async Task<Result<string>> AddAsync(StudentRegisterRequest request)
    {
        var student = new Student
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Mobile = request.PhoneNumber,
            Nic = request.Nic,
            DateOfBirth = request.DateOfBirth,
            Address = request.Address,
            ImageUrl = request.ImageUrl
        };

        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();

        return Result.Ok("Student registered successfully");
    }

    public async Task<Result<string>> DeleteAsync(int id)
    {
        var student = await _context.Students
            .FirstOrDefaultAsync(student => student.Id == id);

        if (student is null)
            return Result.Fail<string>("No student found to delete");

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();

        return Result.Ok("Student deleted successfully");
    }

    public async Task<Result<string>> UpdateAsync(StudentPutRequest request, int id)
    {
        var existingStudent = await _context.Students
            .FirstOrDefaultAsync(student => student.Id == id && id == request.Id);

        if (existingStudent is null)
            return Result.Fail<string>("No student found to update");

        existingStudent.FirstName = request.FirstName;
        existingStudent.LastName = request.LastName;
        existingStudent.Email = request.Email;
        existingStudent.Mobile = request.PhoneNumber;
        existingStudent.Nic = request.Nic;
        existingStudent.DateOfBirth = request.DateOfBirth;
        existingStudent.Address = request.Address;
        existingStudent.ImageUrl = request.ImageUrl;

        await _context.SaveChangesAsync();

        return Result.Ok("Student updated successfully");
    }

    public async Task<Result<IEnumerable<StudentSearchResponse>>> FilterAsync(StudentsSearchRequest request)
    {
        var query = _context.Students.AsQueryable();

        if (!string.IsNullOrEmpty(request.SearchText))
        {
            query = query.Where(student =>
                student.FirstName.Contains(request.SearchText) ||
                student.LastName.Contains(request.SearchText) ||
                student.Email.Contains(request.SearchText));
        }

        query = !string.IsNullOrEmpty(request.SortColumn)
            ? request.SortColumn.ToLower() == "firstname" ? request.SortOrder?.ToLower() == "desc"
                ? query.OrderByDescending(s => s.FirstName)
                : query.OrderBy(s => s.FirstName) :
            request.SortColumn.ToLower() == "lastname" ? request.SortOrder?.ToLower() == "desc"
                ? query.OrderByDescending(s => s.LastName)
                : query.OrderBy(s => s.LastName) :
            request.SortColumn.ToLower() == "email" ? request.SortOrder?.ToLower() == "desc"
                ? query.OrderByDescending(s => s.Email)
                : query.OrderBy(s => s.Email) : query.OrderBy(s => s.Id)
            : query.OrderBy(s => s.Id);

        var filteredStudents = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(student => StudentSearchResponse.FromEntity(student))
            .ToListAsync();

        return Result.Ok<IEnumerable<StudentSearchResponse>>(filteredStudents);
    }
}