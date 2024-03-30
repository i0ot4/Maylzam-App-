
using Maylzam_MVC_.Repository.Implementation;
using Maylzam_MVC_.Repository.IRepository;
using Maylzam_MVC_.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<DbDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("connection"))
);

builder.Services.AddScoped<ITaxiDriverRepository, TaxiDriverRepository>();
builder.Services.AddScoped<ITaxiDriverVechicleRepository, TaxiDriverVechicleRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ITaxiDriverTripRepository, TaxiDriverTripRepository>();
builder.Services.AddScoped<ITaxiDriverAcceptedTripRepository, TaxiDriverAcceptedTripRepository>();
builder.Services.AddScoped<ITaxiDriverNotificationRepository, TaxiDriverNotificationRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<ITaxiDriverReportRepository, TaxiDriverReportRepository>();
builder.Services.AddScoped<IAutomMechanicSkillReposiyory, AutomMechanicSkillReposiyory>();
builder.Services.AddScoped<IAutomMechanicEmployeeReposiyory, AutomMechanicEmployeeReposiyory>();
builder.Services.AddScoped<IAutomMechanicReposiyory, AutomMechanicReposiyory>();
builder.Services.AddScoped<IAutomMechanicNotificationReposiyory, AutomMechanicNotificationReposiyory>();

builder.Services.AddScoped<IAutomMechanicRequestReposiyory, AutomMechanicRequestReposiyory>();
builder.Services.AddScoped<IAutomMechanicAcceptedRequestReposiyory, AutomMechanicAcceptedRequestReposiyory>();
builder.Services.AddScoped<IAutomMechanicReportReposiyory, AutomMechanicReportReposiyory>();
builder.Services.AddScoped<ITrafficPoliceReposiyory, TrafficPoliceReposiyory>();
builder.Services.AddScoped<ITrafficPoliceNotificationReposiyory, TrafficPoliceNotificationReposiyory>();
builder.Services.AddScoped<ITrafficPoliceRequestReposiyory, TrafficPoliceRequestReposiyory>();
builder.Services.AddScoped<ITrafficPoliceAcceptedRequestReposiyory, TrafficPoliceAcceptedRequestReposiyory>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();

app.UseAuthorization();

    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TaxiDriver}/{action=Index}/{id?}");

app.Run();
