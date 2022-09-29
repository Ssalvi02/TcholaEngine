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
        public int XSize, YSize;
        public char Symb;

        public static void PrintAtPosition(int x, int y, char symb)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symb);
        }
    }

    public class Rect : Shape
    {
        public Rect(int whidth, int height, char symb)
        {
            XSize = height;
            YSize = whidth;
            Symb = symb;
        }
        public void Draw(int Posx, int Posy)
        {
            for (int y = Posy; y < Posy + XSize; y++)
            {
                for (int x = Posx; x < Posx + YSize; x++)
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
        public Triangle(char mode, int base_size, char symb)
        {
            MODE = mode;
            XSize = base_size;
            Symb = symb;
        }

        public void Draw(int Posx, int Posy)
        {
            if(MODE == 'e')
            {
                for(int i = 1; i <= XSize; i++)      
                {          
                    for(int j = 1; j <= XSize - i; j++)      
                    {      
                        PrintAtPosition(Posx, Posy, ' ');
                        Posx++; 
                    }      
                    for(int k = 1; k <= i; k++)      
                    {      
                        PrintAtPosition(Posx, Posy, Symb);
                        Posx++;   
                    }      
                    for(int l = i - 1; l >= 1; l--)      
                    {      
                        PrintAtPosition(Posx, Posy, Symb);
                        Posx++;    
                    }      
                    Console.Write("\n");      
                    Posy++;
                }    
            }
            else if (MODE == 's')
            {
                for (int i = 1; i <= XSize; i++)  
                {  
                    for (int j = 1; j <= i; j++)  
                    {  
                        PrintAtPosition(Posx, Posy, Symb);
                        Posx++;
                    }
                    Console.Write("\n"); 
                    Posy++;
                }  
            }
        }
    }

    public class Circle : Shape
    {
        //Falta printar na posição;
        public Circle(int radius, char symb)
        {
            XSize = radius;
            Symb = symb;
        }

        public void Draw(int Posx, int Posy)
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
}