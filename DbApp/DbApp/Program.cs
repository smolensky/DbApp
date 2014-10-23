using System;

namespace DbApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Input first name:");
            var firstName = Console.ReadLine();

            Console.WriteLine("Input second name:");
            var secondName = Console.ReadLine();

            Console.WriteLine("Choose your faculty:");
            var facultyId = Console.ReadLine();

            Console.WriteLine("Input overal mark:");
            var overalMark = Console.ReadLine();

            Console.WriteLine("Hello " + firstName + secondName);
            Console.WriteLine("Your faculty is " + facultyId);
            Console.WriteLine("Your overal mark is " + overalMark);

            Console.ReadKey();
        }
    }

    public class StudentsRepo
    {
        
    }

    public class StudentsDto
    {
        
    }
}
