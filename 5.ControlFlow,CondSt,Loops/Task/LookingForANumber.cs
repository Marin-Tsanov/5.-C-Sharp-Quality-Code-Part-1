using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class LookingForANumber
    {
        public void FindExpectedValue(int expectedValue)
        {
            int[] values = new int[100];

            for (int i = 0; i < values.Length; i++)
            {
                if (i % 10 == 0)
                {
                    Console.WriteLine(values[i]);

                    if (values[i] == expectedValue)
                    {
                        Console.WriteLine("Value Found");
                        break;
                    }
                }
            }
        }
    }
}
