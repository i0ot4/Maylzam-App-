using Maylzam_App_.Model;
using Maylzam_App_.Repository.Implementation;
using Maylzam_App_.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//»‰«¡ «·« ’«· »ﬁÊ«⁄œ «·»Ì«‰« 
builder.Services.AddDbContext<DbDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("connection"));
});

builder.Services.AddScoped<ITaxiDriverRepository, TaxiDriverRepository>();
builder.Services.AddScoped<IVechicleRepository, VechicleRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ITripRepository, TripRepository>();
builder.Services.AddScoped<IAcceptedTripRepository, AcceptedTripRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<ISkillReposiyory, SkillReposiyory>();
builder.Services.AddScoped<IEmployeeReposiyory, EmployeeReposiyory>();
builder.Services.AddScoped<IAutomMechanicReposiyory, AutomMechanicReposiyory>();
builder.Services.AddScoped<IMNotificationReposiyory, MNotificationReposiyory>();
builder.Services.AddScoped<ITripRepository, TripRepository>();
builder.Services.AddScoped<IMaintenanceRReposiyory, MaintenanceRReposiyory>();
builder.Services.AddScoped<IAcceptedMRReposiyory, AcceptedMRReposiyory>();
builder.Services.AddScoped<IMReportReposiyory, MReportReposiyory>();
builder.Services.AddScoped<ITrafficPoliceReposiyory, TrafficPoliceReposiyory>();
builder.Services.AddScoped<ITPNotificationReposiyory, TPNotificationReposiyory>();
builder.Services.AddScoped<ITPRequestReposiyory, TPRequestReposiyory>();
builder.Services.AddScoped<ITPAcceptedRequestReposiyory, TPAcceptedRequestReposiyory>();


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
