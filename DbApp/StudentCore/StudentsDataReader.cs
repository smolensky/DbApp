using System.Data.Entity;
using System.Linq;

namespace StudentCore
{
    public class StudentsDataReader
    {
        private readonly DatabaseContext _databaseContext;

        public StudentsDataReader(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public StudentEntity Create(StudentEntity entity)
        {
            var result = _databaseContext.Students.Add(entity);
            _databaseContext.SaveChanges();
            return result;
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