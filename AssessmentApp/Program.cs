using AssessmentApp.Data;
using AssessmentApp.Repository;
using AssessmentApp.Repository.MsSQL;
using AssessmentApp.Repository.InMemory;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<EMSDbContext>();
builder.Services.AddScoped<EMSDbContext, EMSDbContext>();

builder.Services.AddScoped<IDepartment, DeptDBRepository>();
builder.Services.AddScoped<IEmployee, EmpDBRepository>();
builder.Services.AddSingleton<IIEmployee, InMemoryEmpRepository>();
builder.Services.AddSingleton<IIDepartment, InMemoryDeptRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.Automigrate();

app.UseRouting();


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
