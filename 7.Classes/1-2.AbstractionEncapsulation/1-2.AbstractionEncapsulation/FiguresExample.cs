namespace AbstractionAndEncapsulation
{
    using System;

    public class FiguresExample
    {
        public static void Main()
        {
            IFigure circle = new Circle(5.0);

            var circlePerimeter = circle.CalculatePerimeter();
            var circleSurface = circle.CalculateSurface();

            Console.WriteLine("I am circle. My perimeter is {0:F2}. My surface is {1:F2}", circlePerimeter, circleSurface);

            IFigure rectangle = new Rectangle(2.0, 3.0);

            var rectanglePerimeter = rectangle.CalculatePerimeter();
            var rectangleSurface = rectangle.CalculateSurface();

            Console.WriteLine("I am rectangle. My perimeter is {0:F2}. My surface is {1:F2}", rectanglePerimeter, rectangleSurface);
        }
    }
}