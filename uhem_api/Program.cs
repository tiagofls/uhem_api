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

builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

builder.Services.AddScoped<ICaregiverService, CaregiverService>();
builder.Services.AddScoped<ICaregiverRepository, CaregiverRepository>();

builder.Services.AddScoped<ILoginInfoService, LoginInfoService>();
builder.Services.AddScoped<ILoginInfoRepository, LoginInfoRepository>();

builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();

builder.Services.AddScoped<ITravelService, TravelService>();
builder.Services.AddScoped<ITravelRepository, TravelRepository>();

builder.Services.AddScoped<IHealthFacilityService, HealthFacilityService>();
builder.Services.AddScoped<IHealthFacilityRepository, HealthFacilityRepository>();

builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<IDriverRepository, DriverRepository>();

builder.Services.AddScoped<ITransportCompanyService, TransportCompanyService>();
builder.Services.AddScoped<ITransportCompanyRepository, TransportCompanyRepository>();

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

