using ExpenseTracker.Model;
using ExpenseTracker.Repositories;
using ExpenseTracker.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using AutoMapper;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Inject Dbcontext - Dependecy Injection
builder.Services.AddDbContext<ExpenseTrackerContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("VideoShopConnectionString")));

// Register services and repositories
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

//Configure Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("allowSpecificExpenseTrackerUI", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Configure AutoMapper
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddSingleton<Profile, MappingProfile>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Use Cors
app.UseCors("allowSpecificExpenseTrackerUI");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

