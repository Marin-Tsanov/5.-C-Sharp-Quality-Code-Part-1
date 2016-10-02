using System;

namespace Methods
{
   public class Methods
    {
       internal static double CalculateTriangleArea(double a, double b, double c)
        {
            bool sidesAreEqualOrLessThanZero = (a <= 0 || b <= 0 || c <= 0);

            if (sidesAreEqualOrLessThanZero)
            {
                throw new ArgumentOutOfRangeException("Sides should be positive");
            }

            double halfTrianglePerimeter = (a + b + c) / 2;
            double areaTriangle = Math.Sqrt(halfTrianglePerimeter * 
                                           (halfTrianglePerimeter - a) *
                                           (halfTrianglePerimeter - b) * 
                                           (halfTrianglePerimeter - c));
            return areaTriangle;
        }

        internal static string DigitToWord(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new InvalidOperationException("Invalid number!");
            }
        }

        internal static int FindMax(params int[] elements)
        {
            bool elementsArrayIsNull = (elements == null);
            bool elementsArraysLenghtIsZero = (elements.Length == 0);

            if (elementsArrayIsNull || elementsArraysLenghtIsZero)
            {
                throw new ArgumentOutOfRangeException("Array is empty");
            }

            int max = int.MinValue;

            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] > max)
                {
                    max = elements[i];
                }
            }

            return max;
        }

        internal static void PrintAsNumber(object number, string format)
        {
            switch (format)
            {
                case "f": Console.WriteLine("{0:f2}", number); break;
                case "%": Console.WriteLine("{0:p0}", number); break;
                case "r": Console.WriteLine("{0,8}", number); break;
                default: throw new InvalidOperationException("Please enter valid format");
            }
        }

        internal static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        internal static bool IsHorizontal(double y1, double y2)
        {
            bool isHorizontal = (y1 == y2);
            return isHorizontal;
        }

        internal static bool IsVertical(double x1, double x2)
        {
            bool isVertical = (x1 == x2);
            return isVertical;
        }
    }
}