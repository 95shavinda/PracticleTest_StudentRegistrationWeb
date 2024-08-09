using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using StudentRegistration.Application.Core;
using StudentRegistration.Application.Requests;
using StudentRegistration.Application.Responses;
namespace StudentRegistration.API.Controllers;

[Route("api/students")]
[ApiController]
public class StudentsController(
    IStudentService studentService) : ControllerBase
{
    private readonly IStudentService _studentService = studentService;

    [HttpGet]
    public async Task<ActionResult<Envelope<IEnumerable<StudentGetResponse>>>> Get()
    {
        var result = await _studentService.GetAsync();
        if (!result.IsSuccess)
            return NotFound(Envelope.Error(result.Error));

        return Ok(Envelope.Ok(result.Value));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Envelope<StudentGetResponse>>> Get(int id)
    {
        var result = await _studentService.GetAsync(id);
        if (!result.IsSuccess)
            return NotFound(Envelope.Error(result.Error));

        return Ok(Envelope.Ok(result.Value));
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] StudentRegisterRequest request)
    {
        var modelState = request.Validate();
        if (!modelState.Success) 
            return BadRequest(modelState);

        var result = await _studentService.AddAsync(request);
        if (!result.IsSuccess)
            return BadRequest(Envelope.Error(result.Error));

        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _studentService.DeleteAsync(id);
        if (!result.IsSuccess)
            return BadRequest(Envelope.Error(result.Error));

        return Ok(result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] StudentPutRequest request)
    {
        var modelState = request.Validate();
        if (!modelState.Success) 
            return BadRequest(modelState);

        var result = await _studentService.UpdateAsync(request,id);
        if (!result.IsSuccess)
            return BadRequest(Envelope.Error(result.Error));

        return Ok(result);
    }

    [HttpGet("filtered")]
    public async Task<ActionResult<Envelope>> Filter([FromQuery] StudentsSearchRequest request)
    {
        var result = await _studentService.FilterAsync(request);
        if (!result.IsSuccess)
            return NotFound(Envelope.Error(result.Error));

        return Ok(Envelope.Ok(result.Value));
    }
}