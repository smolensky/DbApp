using System.Linq;

namespace StudentCore
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