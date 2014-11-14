using System.Data.Entity;
using StudentCore;
using WebDbApp.Entities;

namespace WebDbApp
{
    public class DatabaseContext : DbContext
    {
        public DbSet<StudentEntity> Students { get; set; }

        public DbSet<FacultyEntity> Faculties { get; set; }
    }
}