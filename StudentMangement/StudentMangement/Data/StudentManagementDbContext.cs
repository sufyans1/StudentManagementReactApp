using Microsoft.EntityFrameworkCore;
using StudentMangement.Models;

namespace StudentMangement.Data
{
    public class StudentManagementDbContext : DbContext
    {
        public StudentManagementDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<StudentModel> Students { get; set; }
    }

}
