using EDU.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EDU.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<StudentOfClassroom> StudentOfClassrooms { get; set; }
        public DbSet<TeacherOfClassroom> TeacherOfClassrooms { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<Register> Registers { get; set; }
    }
}
