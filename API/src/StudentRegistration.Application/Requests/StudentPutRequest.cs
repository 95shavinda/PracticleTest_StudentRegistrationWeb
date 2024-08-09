using SharedKernel;
using StudentRegistration.Application.Requests.Common;

namespace StudentRegistration.Application.Requests;

public record StudentPutRequest(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    string Nic,
    DateOnly DateOfBirth,
    string Address,
    string ImageUrl
) : ICommandRequest, IStudentRequest
{
    public Envelope Validate()
    {
        var errors = new StudentPutRequestValidator().Validate(this)
            .Errors.Select(error => error.ErrorMessage).ToList();

        return errors.Count is 0 ? Envelope.Ok() : Envelope.Error(errors);
    }
}