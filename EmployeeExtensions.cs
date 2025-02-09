using System;
using EmployeeLibrary;

namespace Extensions
{
    public static class EmployeeExtensions
    {
        public static void PrintEmployees(this Employee[] employees, int employeeCount)
        {
            if (employeeCount == 0)
            {
                Console.WriteLine("No employee data available.");
            }
            else
            {
                Console.WriteLine("Employee Details:");
                Console.WriteLine("----------------------------");

                for (int i = 0; i < employeeCount; i++)
                {
                    employees[i].DisplayData();
                }
            }
        }
    }
}
