using WebAppData.Entities;

namespace WebAppData.Abstractions
{
    public interface IStudentsEntityWriter
    {
        StudentEntity Create(StudentEntity entity);
    }
}