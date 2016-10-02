namespace CohesionAndCoupling
{
    using System;

    public class UtilsExample
    {
        public static void Main()
        {
            Console.WriteLine(FileNameUtils.GetFileExtension("example"));
            Console.WriteLine(FileNameUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileNameUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileNameUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileNameUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileNameUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:F2}", GeometryUtils.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:F2}", GeometryUtils.CalcDistance3D(5, 2, -1, 3, -6, 4));

            var parallelepiped = new Parallelepiped(3.0, 4.0, 5.0);
            Console.WriteLine("Volume = {0:F2}", parallelepiped.CalculateVolume());
            Console.WriteLine("Diagonal XYZ = {0:F2}", parallelepiped.CalculateDiagonalXYZ());
            Console.WriteLine("Diagonal YZ = {0:F2}", parallelepiped.CalculateDiagonalYZ());
            Console.WriteLine("Diagonal XY = {0:F2}", parallelepiped.CalculateDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:F2}", parallelepiped.CalculateDiagonalXZ());
        }
    }
}