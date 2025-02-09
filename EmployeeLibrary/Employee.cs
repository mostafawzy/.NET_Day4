namespace EmployeeLibrary
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Employee
    {
        private static int idCounter = 1;

        public int ID { get; private set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public int Age { get; set; }
        public readonly Gender Gender;

        public Employee(string name, double salary, int age, Gender gender)
        {
            ID = idCounter++;  
            Name = name;
            Salary = salary;
            Age = age;
            Gender = gender;
        }

        public void DisplayData()
        {
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Salary: {Salary:C}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Gender: {Gender}");
            Console.WriteLine("----------------------------");
        }
    }


    public static class EmployeeExtensions
    {
        public static void PrintEmployees(this Employee[] employees, int employeeCount)
        {
            if (employeeCount == 0)
            {
                Console.WriteLine("No employee data available.");
                return;
            }

            Console.WriteLine("Employee Details:");
            Console.WriteLine("----------------------------");
            for (int i = 0; i < employeeCount; i++)
            {
                employees[i].DisplayData();
            }
        }
    }
}
