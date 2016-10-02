namespace AbstractionAndEncapsulation
{
    using System;

    public static class Validator
    {
        public static void ValidateFigure(double value, string figureElement)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException($"{figureElement} must be positive number!");
            }
        }
    }
}