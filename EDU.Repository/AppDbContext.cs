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
    }
}
