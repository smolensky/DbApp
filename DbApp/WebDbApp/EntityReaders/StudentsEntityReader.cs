using System.Linq;
using WebDbApp.Entities;

namespace WebDbApp.EntityReaders
{
    public class StudentsEntityReader
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