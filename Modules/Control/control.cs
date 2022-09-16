using System;
using System.Collections.Generic;
using System.Text;

namespace CTRL
{
    public class Sys
    {
        static void RemoveScrollBars(int ForegroundColor)
        {
            // 0 = Black; 1 = DarkBlue; 2 = DarkGreen; 3 = DarkCyan; 4 = DarkRed;
            // 5 = DarkMagenta; 6 = DarkYellow; 7 = Gray; 8 = DarkGray; 9 = Blue;
            // 10 = Green; 11 = Cyan; 12 = Red; 13 = Magenta; 14 = Yellow; 15 = White;
            
            Console.ForegroundColor = ForegroundColor;
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
}