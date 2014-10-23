using System;
using System.Data;
using System.Data.Entity.Core.EntityClient;

namespace DbApp
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("If you want to input new student type \"new\"\n" +
                              "press enter to show existing students");
            if (Console.ReadLine() == "new")
            {
                Console.WriteLine("Input first name:");
                var firstName = Console.ReadLine();

                Console.WriteLine("Input second name:");
                var secondName = Console.ReadLine();

                Console.WriteLine("Choose your faculty:\n" +
                                  "1 - Phylosophy\n" +
                                  "2 - Logic\n" +
                                  "3 - Psyvhology");
                int facultyId;
                Int32.TryParse(Console.ReadLine(), out facultyId);

                Console.WriteLine("Input overal mark:");
                decimal overalMark;
                decimal.TryParse(Console.ReadLine(), out overalMark);

                var repo = new StudentsRepo();
                repo.Save(new StudentsDto(firstName, secondName, facultyId, overalMark));

                Console.WriteLine("\nHello " + firstName + " " + secondName);
                Console.WriteLine("Your faculty is " + facultyId);
                Console.WriteLine("Your overal mark is " + overalMark);

                Console.ReadKey();
            }
            else
            {
                var repo = new StudentsRepo();

                Console.WriteLine("Showing table:");
                repo.Load();
                Console.ReadLine();
            }
        }
    }
}
