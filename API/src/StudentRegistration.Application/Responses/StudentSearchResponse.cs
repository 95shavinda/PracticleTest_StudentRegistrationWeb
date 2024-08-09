using StudentRegistration.Domain.Entities;

namespace StudentRegistration.Application.Responses;

public record StudentSearchResponse(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string Mobile
)
{
    public static StudentSearchResponse FromEntity(Student student) => new(
        student.Id,
        student.FirstName,
        student.LastName,
        student.Email,
        student.Mobile
    );
}