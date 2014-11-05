using System.Collections.Generic;
using System.Linq;
using StudentsCore;

namespace WebDbApp.Models
{
    public class StudentsModelValidator
    {
        private readonly FacultyDataReader _facultyDataReader;

        public StudentsModelValidator(FacultyDataReader facultyDataReader)
        {
            _facultyDataReader = facultyDataReader;
        }

        public bool ContainValidData(StudentEntity studentsEntity, out List<string> invalidProperties)
        {
            invalidProperties = new List<string>();

            if (string.IsNullOrEmpty(studentsEntity.FirstName))
            {
                invalidProperties.Add("FirstName");
            }

            if (string.IsNullOrEmpty(studentsEntity.SecondName))
            {
                invalidProperties.Add("SecondName");
            }

            var faculty = _facultyDataReader.ReadAll().FirstOrDefault(s => s.FacultyId == studentsEntity.FacultyId);
            if (faculty == null)
            {
                invalidProperties.Add("FacultyId");
            }

            if (studentsEntity.OveralMark >= 100)
            {
                invalidProperties.Add("OveralMark");
            }

            return !invalidProperties.Any();
        }
    }
}