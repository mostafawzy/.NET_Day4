using System;
using EmployeeLibrary;

class Program
{
    static void Main()
    {
        string[] Menu = { "New", "Display", "Exit" };
        int highlight = 0;
        bool looping = true;

        Employee[] employees = new Employee[3];
        int employeeCount = 0;

        do
        {
            Console.Clear();
            for (int i = 0; i < Menu.Length; i++)
            {
                Console.SetCursorPosition(60, 30 / (Menu.Length + 1) * (i + 1));
                if (i == highlight)
                {
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(Menu[i]);
            }

            Console.ResetColor();

            ConsoleKeyInfo ckey = Console.ReadKey();
            switch (ckey.Key)
            {
                case ConsoleKey.UpArrow:
                    highlight = (highlight == 0) ? Menu.Length - 1 : highlight - 1;
                    break;

                case ConsoleKey.DownArrow:
                    highlight = (highlight == Menu.Length - 1) ? 0 : highlight + 1;
                    break;

                case ConsoleKey.Enter:
                    switch (highlight)
                    {
                        case 0:
                            AddEmployees(ref employees, ref employeeCount);
                            break;
                        case 1:
                            employees.PrintEmployees(employeeCount); 
                            Console.WriteLine("\nPress any key to return to the menu...");
                            Console.ReadKey();
                            break;
                        case 2:
                            looping = false;
                            break;
                    }
                    break;
                case ConsoleKey.Escape:
                    looping = false;
                    break;
            }

        } while (looping);
    }

    static void AddEmployees(ref Employee[] employees, ref int employeeCount)
    {
        for (int i = employeeCount; i < 3; i++)
        {
            Console.Clear();
            Console.WriteLine($"Enter details for Employee {i + 1}:");

            Console.Write("Enter Employee Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Employee Salary: ");
            double salary = double.Parse(Console.ReadLine());

            Console.Write("Enter Employee Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter Gender (M for Male, F for Female): ");
            char genderInput = Console.ReadKey().KeyChar;
            Console.WriteLine();

            Gender gender = (genderInput == 'M' || genderInput == 'm') ? Gender.Male : Gender.Female;

            employees[i] = new Employee(name, salary, age, gender);
            employeeCount++;

            Console.WriteLine("\nEmployee added successfully!");
            Console.WriteLine("Press any key to add the next employee...");
            Console.ReadKey();

            if (employeeCount >= 3) break;
        }
    }
}
