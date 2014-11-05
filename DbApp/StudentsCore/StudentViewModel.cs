namespace StudentsCore
{
    public class StudentViewModel
    {
        public StudentViewModel(string firstName, string secondName, int facultyId, decimal overalMark)
        {
            OveralMark = overalMark;
            FacultyId = facultyId;
            SecondName = secondName;
            FirstName = firstName;
        }

        public string FirstName { get; private set; }

        public string SecondName { get; private set; }

        public int FacultyId { get; private set; }

        public decimal OveralMark { get; private set; }
    }
}