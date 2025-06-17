using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApplication1;
using WebApplication1.Controllers;
using WebApplication1.DBaccess;
using WebApplication1.EntityManager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DoctorLogic>();
builder.Services.AddScoped<BillingLogic>();
builder.Services.AddScoped<PatientLogic>();
builder.Services.AddScoped<PrescriptionLogic>();
builder.Services.AddScoped<MedicationLogic>();
builder.Services.AddScoped<AppointmentLogic>();
builder.Services.AddScoped<AccountManager>();

builder.Services.AddScoped<DoctorsController>();
builder.Services.AddScoped<PatientsController>();
builder.Services.AddScoped<BillingsController>();
builder.Services.AddScoped<PrescriptionsController>();
builder.Services.AddScoped<MedicationsController>();
builder.Services.AddScoped<AppointmentsController>();
builder.Services.AddScoped<AccountController>();

var mySkey = "sdfsdfkasdfajsfkLsdfsdfkasdfajsfkL";
SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(mySkey));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters {
        ValidateIssuer = false,
        ValidateIssuerSigningKey=true,

        ValidateLifetime = true,//23849242
        ValidateAudience = false,
        IssuerSigningKey= securityKey
    };
});
string connstr = builder.Configuration.GetConnectionString("defaultConnection");
builder.Services.AddDbContext<MyDBContext>(opt => opt.UseSqlServer(connstr));
var app = builder.Build();


    app.UseSwagger();
    app.UseSwaggerUI();

app.UseAuthentication();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
