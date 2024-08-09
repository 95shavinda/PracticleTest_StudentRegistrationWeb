using StudentRegistration.API.Common;
using StudentRegistration.Application;
using StudentRegistration.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddExceptionHandler<GlobalExceptionHandler>();
services.AddCorsPolicies(configuration);
services
    .AddApplication(configuration)
    .AddInfrastructure(configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors();

app.Run();