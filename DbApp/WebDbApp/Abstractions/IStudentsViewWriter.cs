using WebDbApp.Models;

namespace WebDbApp.Abstractions
{
    public interface IStudentsViewWriter
    {
        StudentViewModel Create(StudentViewModel model);
    }
}