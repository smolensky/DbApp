using System.Linq;
using StudentCore;
using WebDbApp.EntityReaders;

namespace WebDbApp.DataReaders
{
    public class FacultyDataReader
    {
        private readonly DatabaseContext _databaseContext;

        public FacultyDataReader(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IQueryable<FacultyEntity> ReadAll()
        {
            return _databaseContext.Faculties;
        }
    }
}