using System;
using StudentsCore;

namespace DbApp
{
    internal class Program
    {
        private static void Main()
        {
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
                    foreach (StudentsDto student in repo.Load())
                    {
                        Console.WriteLine("\n" + student.FirstName);
                        Console.WriteLine(student.SecondName);
                        Console.WriteLine(student.FacultyId);
                        Console.WriteLine(student.OveralMark);
                    }
                    
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
}