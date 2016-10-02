using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    public class Startup
    {
       public static void Main()
        {
            string firstName = "Peter";
            string lastName = "Ivanov";
            Student peter = new Student(firstName,lastName);
            peter.OtherInformation = "From Sofia, born at 03.17.1992";

            string firstNameStudent = "Stella";
            string lastNameStudent = "Markova";
            Student stella = new Student(firstNameStudent,lastNameStudent);
            stella.OtherInformation = "From Vidin, gamer, high results, born at 11.03.1993";

            Console.WriteLine("{0} older than {1} -> {2}",
                               peter.LastName, stella.LastName, peter.IsOlderThan(stella));
        }
    }
}
