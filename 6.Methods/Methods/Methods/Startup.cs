using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    public class Startup
    {
        static void Main()
        {
            Console.WriteLine(Methods.CalculateTriangleArea(3, 4, 5));

            Console.WriteLine(Methods.DigitToWord(5));

            Console.WriteLine(Methods.FindMax(5, -1, 3, 2, 14, 2, 3));

            Methods.PrintAsNumber(1.3, "f");
            Methods.PrintAsNumber(0.75, "%");
            Methods.PrintAsNumber(2.30, "r");

            Console.WriteLine(Methods.CalcDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + Methods.IsHorizontal(-1, 2.5));
            Console.WriteLine("Vertical? " + Methods.IsVertical(3, 3));
        }
    }
}
