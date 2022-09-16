using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace GEOM
{
    public class Shape
    {
        public int XSize, YSize, PosX, PosY;
        public char Symb;

        public static void PrintAtPosition(int x, int y, char symb)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symb);
        }
    }

    public class Rect : Shape
    {
        public Rect(int b, int h, char symb, int x, int y)
        {
            XSize = h;
            YSize = b;
            PosX = x;
            PosY = y;
            Symb = symb;
        }
        public void Draw()
        {
            for (int y = PosY; y < PosY + XSize; y++)
            {
                for (int x = PosX; x < PosX + YSize; x++)
                {
                    PrintAtPosition(x, y, Symb);
                }
            }
        }
    }

    public class Triangle : Shape
    {
        public Triangle()
        {

        }
    }

    public class Circle : Shape
    {
        public Circle(int radius, char symb, int x, int y)
        {
            XSize = radius;
            PosX = x;   
            PosY = y;
            Symb = symb;
        }

        public void Draw()
        {
            switch (XSize)
            {
                case 0:
                    PrintAtPosition(PosX, PosY, Symb);
                    break;
                default:
                    double thickness = 0.1;
                    Console.WriteLine();
                    double rIn = XSize - thickness, rOut = XSize + thickness;

                    for (double y = XSize; y >= -XSize; --y)
                    {
                        for (double x = -XSize; x < rOut; x += 0.5)
                        {
                            double value = x * x + y * y;
                            if (value >= rIn * rIn && value <= rOut * rOut)
                            {
                                Console.Write(Symb);
                            }
                            else
                            {
                                Console.Write(" ");
                            }
                        }
                        Console.WriteLine();
                    }
                    break;
            }
        } 
    }

    class prog
    {
        static void Main()
        {
            Circle c = new Circle(2, '*', 80, 5);

            Console.Clear();
            c.Draw();
        }
    }
}