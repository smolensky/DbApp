using System.Collections.Generic;
using WebDbApp.Models;

namespace WebDbApp.Abstractions
{
    public interface IStudentsModelValidator
    {
        bool ContainValidData(StudentViewModel model, out List<string> invalidProperties);
    }
}