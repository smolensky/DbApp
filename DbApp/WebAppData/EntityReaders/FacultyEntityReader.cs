using System.Linq;
using WebAppData.Abstractions;
using WebAppData.Entities;

namespace WebAppData.EntityReaders
{
    public class FacultyEntityReader : IFacultyEntityReader
    {
        private readonly DatabaseContext _databaseContext;

        public FacultyEntityReader(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IQueryable<FacultyEntity> ReadAll()
        {
            return _databaseContext.Faculties.AsQueryable();
        }
    }
}