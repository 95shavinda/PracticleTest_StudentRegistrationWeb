using FluentValidation;

namespace StudentRegistration.Application.Requests;

public class StudentPutRequestValidator : StudentBaseValidator<StudentPutRequest>
{
    public StudentPutRequestValidator() =>
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than 0.");
}