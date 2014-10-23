using System;

namespace DbApp
{
    class Program
    {
        private readonly StudentsRepo _repo;

        public Program(StudentsRepo repo)
        {
            _repo = repo;
        }

        static void Main()
        {
            Console.WriteLine("Input first name:");
            var firstName = Console.ReadLine();

            Console.WriteLine("Input second name:");
            var secondName = Console.ReadLine();

            Console.WriteLine("Choose your faculty:");
            int facultyId;
            Int32.TryParse(Console.ReadLine(), out facultyId);

            Console.WriteLine("Input overal mark:");
            decimal overalMark;
            decimal.TryParse(Console.ReadLine(), out overalMark);



            Console.WriteLine("Hello " + firstName + secondName);
            Console.WriteLine("Your faculty is " + facultyId);
            Console.WriteLine("Your overal mark is " + overalMark);

            Console.ReadKey();
        }
    }
}
