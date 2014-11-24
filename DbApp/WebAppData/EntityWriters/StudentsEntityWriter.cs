using WebAppData.Abstractions;
using WebAppData.Entities;

namespace WebAppData.EntityWriters
{
    public class StudentsEntityWriter : IStudentsEntityWriter
    {
        private readonly DatabaseContext _databaseContext;

        public StudentsEntityWriter(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public StudentEntity Create(StudentEntity entity)
        {
            var result = _databaseContext.Students.Add(entity);
            _databaseContext.SaveChanges();
            return result;
        }
    }
}