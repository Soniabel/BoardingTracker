using BoardingTracker.Application.Candidates.Queries.GetAllCandidates;
using BoardingTracker.Application.Infrastructure.Mapper;
using BoardingTracker.WebApi.Infrastructure.Data.Extensions;
using FluentValidation;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

await builder.Services.AddDatabase(builder.Configuration);

builder.Services.AddMediatR(typeof(GetCandidates).GetTypeInfo().Assembly);
//builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
builder.Services.AddAutoMapper(typeof(BoardingTrackerMappingProfile));
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
