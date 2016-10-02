using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1
{
    public class Program
    {
        static void Main()
        {
            List<Employee> list = new List<Employee>();
            list.Add(new Employee() { Name = "Steve", Salary = 10000 });
            list.Add(new Employee() { Name = "Janet", Salary = 10000 });
            list.Add(new Employee() { Name = "Andrew", Salary = 10000 });
            list.Add(new Employee() { Name = "Bill", Salary = 500000 });
            list.Add(new Employee() { Name = "Lucy", Salary = 8000 });

            // Uses IComparable.CompareTo()
            list.Sort();

            // Uses Employee.ToString
            foreach (var element in list)
            {
                Console.WriteLine(element);
            }
        }
    }
}

