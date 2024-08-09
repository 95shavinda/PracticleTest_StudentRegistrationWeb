using SharedKernel;

namespace StudentRegistration.Application.Requests.Common;

public interface ICommandRequest
{
    Envelope Validate();
}