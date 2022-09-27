using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


//Problemas: Assincorinicidade de pegar input e como pegar caracteres especiais
namespace CONTROL
{
    public class Sys
    {
        static void RemoveScrollBars(System.ConsoleColor FC)
        {
            // 0 = Black; 1 = DarkBlue; 2 = DarkGreen; 3 = DarkCyan; 4 = DarkRed;
            // 5 = DarkMagenta; 6 = DarkYellow; 7 = Gray; 8 = DarkGray; 9 = Blue;
            // 10 = Green; 11 = Cyan; 12 = Red; 13 = Magenta; 14 = Yellow; 15 = White;
            
            Console.ForegroundColor = FC;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }

        static int GetWindowH()
        {
            return Console.WindowHeight;
        }
        static int GetWindowW()
        {
            return Console.WindowWidth;
        }

    }

    public enum KeyCode
    {
        A = 'A', B = 'B', C = 'C', D = 'D', E = 'E', F = 'F', G = 'G', H = 'H', I = 'I', J = 'J', K = 'K', L = 'L', M = 'M', N = 'N', O = 'O', P = 'P', Q = 'Q', R = 'R', S = 'S', T = 'T', U = 'U', V = 'V', W = 'W', X = 'X', Y = 'Y', Z = 'Z', 
        Space = 32, LeftCtrl, RightCtrl, LeftShift, RightShift, Enter, Backspace, Escape = 27, RightArrow, LeftArrow, UpArrow, DownArrow
    }
    public class Input
    {
        public static bool GetKey(KeyCode k)
        {
            if(Console.ReadKey().Key == ((ConsoleKey)k))
            {
                return true;
            }
            return false;
        }
    }

    class Program
    {
        static volatile bool exit = false;
        static void Main(string[] args)
        {
            Task.Factory.StartNew(() =>
                    {
                        while (Console.ReadKey().Key != ConsoleKey.Q);
                        exit = true;
                    });

                while (!exit)
                {
                    if(Input.GetKey(KeyCode.A))
                    {
                        Console.Write("JAJAjAJA");
                    }
                    if(Input.GetKey(KeyCode.B))
                    {
                        Console.Write("JUJUJUJUJ");
                    }
                    Thread.Sleep(60);
                }
        }
    }
}