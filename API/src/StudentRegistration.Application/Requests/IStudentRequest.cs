namespace StudentRegistration.Application.Requests;

public interface IStudentRequest
{
    string FirstName { get; }
    string LastName { get; }
    string Email { get; }
    string PhoneNumber { get; }
    string Nic { get; }
    DateOnly DateOfBirth { get; }
    string Address { get; }
    string ImageUrl { get; }
}
