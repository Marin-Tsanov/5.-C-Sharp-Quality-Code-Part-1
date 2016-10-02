using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Naming_Identifiers
{
    public class ClassOneTwoThree
    {
        const int maxCount = 6;

        static void Main()
        {
            Entrance();
        }

        class InClassOneTwoThree
        {
           internal void printVariableOnConsole(bool variable)
            {
                string variableToString = variable.ToString();
                Console.WriteLine(variableToString);
            }
        }

        public static void Entrance()
        {
            ClassOneTwoThree.InClassOneTwoThree InClass = new ClassOneTwoThree.InClassOneTwoThree();
            InClass.printVariableOnConsole(true);
        }
    }
}
