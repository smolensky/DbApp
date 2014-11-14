using System.Collections.Generic;
using System.Linq;
using StudentCore;
using WebDbApp.DataReaders;
using WebDbApp.Entities;

namespace WebDbApp.Models
{
    public class StudentsModelValidator
    {
        private readonly FacultyDataReader _facultyDataReader;

        public StudentsModelValidator(FacultyDataReader facultyDataReader)
        {
            _facultyDataReader = facultyDataReader;
        }

        public bool ContainValidData(StudentViewModel model, out List<string> invalidProperties)
        {
            invalidProperties = new List<string>();

            if (string.IsNullOrEmpty(model.FirstName))
            {
                invalidProperties.Add("FirstName");
            }

            if (string.IsNullOrEmpty(model.SecondName))
            {
                invalidProperties.Add("SecondName");
            }

            var faculty = _facultyDataReader.ReadAll().FirstOrDefault(s => s.FacultyId == model.FacultyId);
            if (faculty == null)
            {
                invalidProperties.Add("FacultyId");
            }

            if (model.OveralMark >= 100)
            {
                invalidProperties.Add("OveralMark");
            }

            return !invalidProperties.Any();
        }
    }
}