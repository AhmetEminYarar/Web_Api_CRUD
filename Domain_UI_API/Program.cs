using Domain_DataBase.Domain_Extensions;
using Domain_DTO.Extesions;
using Domain_Servies.Domain_Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.LoadDatabaseExtensions(builder.Configuration);
builder.Services.LoadServicesExtensions();
builder.Services.LoadDtoExtensions();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
