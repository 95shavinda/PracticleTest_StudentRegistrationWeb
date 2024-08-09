using FluentValidation;

namespace StudentRegistration.Application.Requests;

public abstract class StudentBaseValidator<T> : AbstractValidator<T> where T : IStudentRequest
{
    protected StudentBaseValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First Name is required.")
            .MaximumLength(50).WithMessage("First Name must not exceed 50 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last Name is required.")
            .MaximumLength(50).WithMessage("Last Name must not exceed 50 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("A valid email is required.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone Number is required.")
            .Matches(@"^(?:\+?\d{1,3}|\d{1})\s?\d{1,14}(\s?\d{1,13})?$")
            .WithMessage("Phone Number must be in a valid format.");

        RuleFor(x => x.Nic)
            .NotEmpty().WithMessage("NIC is required.")
            .MaximumLength(15).WithMessage("NIC must not exceed 15 characters.");

        RuleFor(x => x.DateOfBirth)
            .NotEmpty().WithMessage("Date of Birth is required.")
            .Must(BeAValidAge).WithMessage("Student must be at least 5 years old.");

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Address is required.")
            .MaximumLength(100).WithMessage("Address must not exceed 100 characters.");

        RuleFor(x => x.ImageUrl)
            .NotEmpty().WithMessage("Image URL is required.")
            .Must(BeAValidUrl).WithMessage("A valid URL is required for the Image.");
    }

    private static bool BeAValidAge(DateOnly dateOfBirth)
    {
        var age = DateTime.Now.Year - dateOfBirth.Year;
        if (dateOfBirth.AddYears(age) > DateOnly.FromDateTime(DateTime.Now)) 
            age--;

        return age >= 5;
    }

    private bool BeAValidUrl(string imageUrl) => 
        Uri.TryCreate(imageUrl, UriKind.Absolute, out _);
}