using uhem_api.Interfaces.Repositories;
using uhem_api.Interfaces.Repository;
using uhem_api.Interfaces.Service;
using uhem_api.Repositories;
using uhem_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITravelPurposeService, TravelPurposeService>();
builder.Services.AddScoped<ITravelPurposeRepository, TravelPurposeRepository>();

builder.Services.AddScoped<IInsuranceService, InsuranceService>();
builder.Services.AddScoped<IInsuranceRepository, InsuranceRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

