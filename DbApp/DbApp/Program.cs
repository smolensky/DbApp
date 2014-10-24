using System;
using Microsoft.Practices.Unity;

namespace DbApp
{
    internal class Program
    {
        private static void Main()
        {
            var container = new UnityContainer();
            var t = container.Resolve<SomeClass>();

            Console.WriteLine("Type 1 and press enter to input new student\n" +
                              "Type 2 and press enter to show existing students\n");
            switch (Console.ReadLine())
            {
                case "1":
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
                    Console.WriteLine("Your overal mark is " + overalMark + "\n");

                    Main();
                }
                    break;
                case "2":
                {
                    var repo = new StudentsRepo();

                    Console.WriteLine("Showing table:");
                    repo.Load();
                    
                    Main();
                }
                    break;
                case "3":
                {
                    
                }
                    break;
            }
        }
    }

    public class SomeClass
    {
        private readonly StudentsRepo _repo;

        public SomeClass(StudentsRepo repo)
        {
            _repo = repo;
        }


    }
}
