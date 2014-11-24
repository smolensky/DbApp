using System.Linq;
using WebAppData.Entities;

namespace WebAppData.Abstractions
{
    public interface IStudentsEntityReader
    {
        IQueryable<StudentEntity> ReadAll();
    }
}