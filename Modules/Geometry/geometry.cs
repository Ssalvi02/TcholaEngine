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
        public Rect(int whidth, int height, char symb, int x, int y)
        {
            XSize = height;
            YSize = whidth;
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
        //Falta desenhar na posição;
        private char MODE;
        public Triangle(char mode, int base_size, char symb, int x, int y)
        {
            MODE = mode;
            XSize = base_size;
            Symb = symb;
            PosX = x;
            PosY = y;
        }

        public void Draw()
        {
            if(MODE == 'e')
            {
                for(int i = 1; i <= XSize; i++)      
                {          
                    for(int j = 1; j <= XSize - i; j++)      
                    {      
                        Console.Write(" ");  
                    }      
                    for(int k = 1; k <= i; k++)      
                    {      
                        Console.Write(Symb);      
                    }      
                    for(int l = i - 1; l >= 1; l--)      
                    {      
                        Console.Write(Symb);      
                    }      
                    Console.Write("\n");      
                }    
            }
            else if (MODE == 's')
            {
                for (int i = 1; i <= XSize; i++)  
                {  
                    for (int j = 1; j <= i; j++)  
                    {  
                        Console.Write("");  
                    }  
                    for (int k = 1; k <= i; k++)  
                    {  
                        Console.Write(Symb);  
                    }
                    Console.Write("\n");      
                }  
            }
        }
    }

    public class Circle : Shape
    {
        //Falta printar na posição;
        public Circle(int radius, char symb, int x, int y)
        {
            XSize = radius;
            PosX = x;   
            PosY = y;
            Symb = symb;
        }

        public void Draw()
        {
            double thickness = 0.2;
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
        } 
    }

    class prog
    {
        static void Main()
        {
            Triangle t = new Triangle('e', 10, '&', 90, 0);

            Console.Clear();
            t.Draw();
        }
    }
}