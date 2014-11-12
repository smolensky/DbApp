using System.Data.Entity;
using System.Linq;
using StudentCore;
using WebDbApp.Entities;

namespace WebDbApp.DataReaders
{
    public class StudentsDataReader
    {
        private readonly DatabaseContext _databaseContext;

        public StudentsDataReader(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IQueryable<StudentEntity> ReadAll()
        {
            var result = _databaseContext.Students;
            return result;
        }
    }

    public class DatabaseContext : DbContext
    {
        public DbSet<StudentEntity> Students { get; set; }

        public DbSet<FacultyEntity> Faculties { get; set; }
    }
}