using System.Linq;
using WebAppData.Entities;

namespace WebAppData.Abstractions
{
    public interface IFacultyEntityReader
    {
        IQueryable<FacultyEntity> ReadAll();
    }
}