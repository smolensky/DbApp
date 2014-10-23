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
    }
}