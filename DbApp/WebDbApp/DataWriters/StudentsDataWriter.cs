using StudentCore;
using WebDbApp.Entities;

namespace WebDbApp.DataReaders
{
    public class StudentsDataWriter
    {
        private readonly DatabaseContext _databaseContext;

        public StudentsDataWriter(DatabaseContext databaseContext)
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