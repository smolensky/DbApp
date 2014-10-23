using System;
using System.Linq;

namespace DbApp
{
    public class StudentsRepo
    {
        public void Save(StudentsDto dto)
        {
            using (var db = new StudentDbContext())
            {
                var student = new Student
                {
                    FirstName = dto.FirstName,
                    SecondName = dto.SecondName,
                    FacultyId = dto.FacultyId,
                    OveralMark = dto.OveralMark
                };

                db.Students.Add(student);

                db.SaveChanges();
            }
        }

        public void Load()
        {
            using (var db = new StudentDbContext())
            {
                var query = from s in db.Students
                    orderby s.FirstName
                    select s;

                foreach (var item in query)
                {
                    Console.WriteLine(item.FirstName + " " + 
                                      item.SecondName + "\n" +
                                      item.FacultyId + "\n" +
                                      item.OveralMark + "\n\n");
                }
            }
        }
    }
}