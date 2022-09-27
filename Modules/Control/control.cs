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
        public static void RemoveScrollBars(int FC)
        {
            // 0 = Black; 1 = DarkBlue; 2 = DarkGreen; 3 = DarkCyan; 4 = DarkRed;
            // 5 = DarkMagenta; 6 = DarkYellow; 7 = Gray; 8 = DarkGray; 9 = Blue;
            // 10 = Green; 11 = Cyan; 12 = Red; 13 = Magenta; 14 = Yellow; 15 = White;
            System.ConsoleColor c = (System.ConsoleColor)FC;
            Console.ForegroundColor = c;
            Console.BufferHeight = GetWindowH();
            Console.BufferWidth = GetWindowW();
        }

        public static int GetWindowH()
        {
            return Console.WindowHeight;
        }
        public static int GetWindowW()
        {
            return Console.WindowWidth;
        }

    }

    public enum KeyCode
    {
        A = 'A', B = 'B', C = 'C', D = 'D', E = 'E', F = 'F', G = 'G', H = 'H', I = 'I', J = 'J', K = 'K', L = 'L', M = 'M', N = 'N', O = 'O', P = 'P', Q = 'Q', R = 'R', S = 'S', T = 'T', U = 'U', V = 'V', W = 'W', X = 'X', Y = 'Y', Z = 'Z', 
        Space = 32, Escape = 27
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
}