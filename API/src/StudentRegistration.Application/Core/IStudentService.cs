using SharedKernel;
using StudentRegistration.Application.Requests;
using StudentRegistration.Application.Responses;

namespace StudentRegistration.Application.Core;

public interface IStudentService
{
    Task<Result<IEnumerable<StudentSearchResponse>>> FilterAsync(StudentsSearchRequest request);
    Task<Result<IEnumerable<StudentGetResponse>>> GetAsync();
    Task<Result<StudentGetResponse>> GetAsync(int id);
    Task<Result<string>> AddAsync(StudentRegisterRequest request);
    Task<Result<string>> UpdateAsync(StudentPutRequest request, int id);
    Task<Result<string>> DeleteAsync(int id);
}