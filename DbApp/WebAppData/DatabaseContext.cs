using System.Data.Entity;
using WebAppData.Entities;

namespace WebAppData
{
    public class DatabaseContext : DbContext
    {
        public DbSet<StudentEntity> Students { get; set; }

        public DbSet<FacultyEntity> Faculties { get; set; }
    }
}