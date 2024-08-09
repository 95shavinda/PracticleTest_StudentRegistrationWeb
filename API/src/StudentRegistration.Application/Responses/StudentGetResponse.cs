using StudentRegistration.Domain.Entities;

namespace StudentRegistration.Application.Responses;

public record StudentGetResponse(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    string Nic,
    DateOnly DateOfBirth,
    string Address,
    string ImageUrl
)
{
    public static StudentGetResponse FromEntity(Student entity) => new(
        entity.Id,
        entity.FirstName,
        entity.LastName,
        entity.Email,
        entity.Mobile,
        entity.Nic,
        entity.DateOfBirth,
        entity.Address,
        entity.ImageUrl
    );
}