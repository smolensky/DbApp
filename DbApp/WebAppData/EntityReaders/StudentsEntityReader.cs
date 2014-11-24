using System.Linq;
using WebAppData.Abstractions;
using WebAppData.Entities;

namespace WebAppData.EntityReaders
{
    public class StudentsEntityReader : IStudentsEntityReader
    {
        private readonly DatabaseContext _databaseContext;

        public StudentsEntityReader(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IQueryable<StudentEntity> ReadAll()
        {
            var result = _databaseContext.Students;
            return result;
        }
    }
}