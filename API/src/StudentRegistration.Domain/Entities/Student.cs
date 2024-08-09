namespace StudentRegistration.Domain.Entities;

public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Mobile { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Nic { get; set; } = default!;
    public DateOnly DateOfBirth { get; set; }
    public string Address { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
}