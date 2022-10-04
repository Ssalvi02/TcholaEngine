using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CONTROL
{
    public class Sys
    {
        public enum ColorCode
        {
            Black = 0, DarkBlue = 1, DarkGreen = 2, DarkCyan = 3, DarkRed = 4,
            DarkMagenta = 5, DarkYellow = 6, Gray = 7, DarkGray = 8, Blue = 9,
            Green = 10, Cyan = 11, Red = 12, Magenta = 13, Yellow = 14, White = 15
        }
        public static void RemoveScrollBars()
        {
            Console.BufferHeight = GetWindowH();
            Console.BufferWidth = GetWindowW();
        }
        public static void RemoveScrollBars(ColorCode FC)
        {
            System.ConsoleColor c = (System.ConsoleColor)FC;
            Console.ForegroundColor = c;
            Console.BufferHeight = GetWindowH();
            Console.BufferWidth = GetWindowW();
        }

        public static int GetWindowH()
        {
            return (int)Console.WindowHeight;
        }
        public static int GetWindowW()
        {
            return (int)Console.WindowWidth;
        }

    }

public enum KeyCode
    {
        VK_BACK = 0x08,
        VK_TAB = 0x09,
        VK_CLEAR = 0x0C,
        VK_RETURN = 0X0D,
        VK_SHIFT  = 0X10,
        VK_CONTROL = 0X11,
        VK_MENU = 0X12,
        VK_PAUSE = 0X13,
        VK_CAPITAL = 0X14,
        VK_ESCAPE = 0X1B,
        VK_SPACE = 0X20,
        VK_PRIOR = 0X21,
        VK_NEXT = 0X22,
        VK_END = 0X23,
        VK_HOME = 0X24,
        VK_LEFT = 0X25,
        VK_UP = 0X26,
        VK_RIGHT = 0X27,
        VK_DOWN = 0X28,
        VK_SELECT = 0X29,
        VK_PRINT = 0X2A,
        VK_INSERT = 0X2D,
        VK_DELETE = 0X2E,
        A = 65,
        B = 66,
        C = 67,
        D = 68,
        E = 69,
        F = 70,
        G = 71,
        H = 72,
        I = 73,
        J = 74,
        K = 75,
        L = 76,
        M = 77,
        N = 78,
        O = 79,
        P = 80,
        Q = 81,
        R = 82,
        S = 83,
        T = 84,
        U = 85,
        V = 86,
        W = 87,
        X = 88,
        Y = 89,
        Z = 90
    }

    public class Input
    {
        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(int Vkey);

        public static short GetAsyncKeyState(KeyCode Kc)
        {
            return GetAsyncKeyState((int)Kc);
        }
        public static bool GetKey(KeyCode k)
        {
            if(GetAsyncKeyState(k) != 0)
            {
                return true;
            }
            return false;
        }
    }

}