using System.Collections.Generic;
using WebDbApp.Models;

namespace WebDbApp.Abstractions
{
    public interface IStudentsViewReader
    {
        IEnumerable<StudentViewModel> ReadAll();
    }
}