using System;
using System.Runtime.InteropServices;

namespace TestDLL
{
    class Program
    {
        [DllImport("C:\\Users\\Acer\\source\\repos\\MyLib\\Debug\\MyLib.dll")]
        public static extern double SquareRect(double Side1, double Side2);

        [DllImport("C:\\Users\\Acer\\source\\repos\\MyLib\\Debug\\MyLib.dll")]
        public static extern double SquareTr(double Side1, double Side2);

        static void Main(string[] args)
        {
            double Square = SquareRect(4.5, 6.5);
            double SquareTriangle = SquareTr(4.5, 6.7);

            Console.WriteLine($" Square of Triangle = {SquareTriangle}");
            Console.WriteLine($" Square of Rectangle = {Square}");
        }
    }
}