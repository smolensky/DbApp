using WebDbApp.Entities;
using WebDbApp.Models;

namespace WebDbApp
{
    public class Mapper
    {

        public static StudentEntity Map(StudentViewModel model)
        {
            var result = new StudentEntity
            {
                FirstName = model.FirstName,
                SecondName = model.SecondName,
                FacultyId = model.FacultyId,
                OveralMark = model.OveralMark
            };

            return result;
        }

        public static StudentViewModel Map(StudentEntity entity)
        {
            var result = new StudentViewModel
            {
                FirstName = entity.FirstName,
                SecondName = entity.SecondName,
                FacultyId = entity.FacultyId,
                OveralMark = entity.OveralMark
            };

            return result;
        }
    }
}