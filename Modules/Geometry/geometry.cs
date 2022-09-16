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

        static void PrintAtPosition(int x, int y, char symb)
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
}