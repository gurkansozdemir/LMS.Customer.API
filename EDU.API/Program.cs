using EDU.Core.Entities;
using EDU.Core.Repositories;
using EDU.Core.Services;
using EDU.Core.UnitOfWorks;
using EDU.Repository;
using EDU.Repository.Repositories;
using EDU.Repository.UnitOfWorks;
using EDU.Service.Mapping;
using EDU.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<AppDbContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"))
);
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                      });
});

builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
builder.Services.AddScoped(typeof(IUserService), typeof(UserService));

builder.Services.AddScoped(typeof(IClassroomRepository), typeof(ClassroomRepository));
builder.Services.AddScoped(typeof(IClassroomService), typeof(ClassroomService));

builder.Services.AddScoped(typeof(IActivityRepository), typeof(ActivityRepository));
builder.Services.AddScoped(typeof(IActivityService), typeof(ActivityService));

builder.Services.AddScoped(typeof(IInspectionRepository), typeof(InspectionRepository));
builder.Services.AddScoped(typeof(IInspectionService), typeof(InspectionService));

builder.Services.AddScoped(typeof(ILessonRepository), typeof(LessonRepository));
builder.Services.AddScoped(typeof(ILessonService), typeof(LessonService));

builder.Services.AddScoped(typeof(IRegisterRepository), typeof(RegisterRepository));
builder.Services.AddScoped(typeof(IRegisterService), typeof(RegisterService));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();
