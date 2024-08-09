namespace StudentRegistration.Application.Requests;

public record StudentsSearchRequest(
    int PageNumber = 1,
    int PageSize = 10,
    string? SearchText = null,
    string? SortOrder = null,
    string? SortColumn = null
);