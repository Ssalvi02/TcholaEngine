using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


namespace GEOM
{
    public class Rect
    {
        public int H, B, PosX, PosY;
        public char Symb;

        public Rect(int b, int h, char symb, int posx, int posy)
        {
            H = h;
            B = b;
            PosX = posx;
            PosY = posy;
            Symb = symb;
        }

        public void Draw()
        {
            for (int y = PosY; y < PosY + B; y++)
            {
                for (int x = PosX; x < PosX + H; x++)
                {
                    PrintAtPosition(x, y, Symb);
                }
            }
        }
        static void PrintAtPosition(int x, int y, char symb)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symb);
        }
    }
    class Triangle
    {

    }
}