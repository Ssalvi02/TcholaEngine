using System;
using System.Threading;
using CONTROL;
using GEOM;

namespace PONG
{
    class Program
    {
            //Geral
            static int screen_h = Sys.GetWindowH();
            static int screen_w = Sys.GetWindowW();

            //Pad 1
            static int pad_1_size_y = 6;
            static int pad_1_size_x = 3;
            static int posx_1 = screen_w - pad_1_size_x;
            static int posy_1 = (screen_h/2) - (pad_1_size_y/2);

            
            //Pad 2
            static int pad_2_size_y = 6;
            static int pad_2_size_x = 3;
            static int posx_2 = 0;
            static int posy_2 = (screen_h/2) - (pad_1_size_y/2);

        static void ControlPad1()
        {
            if(posy_1 < 1)
            {
                posy_1 = 0;
            }
            if(posy_1 > (screen_h - pad_1_size_y) - 1)
            {
                posy_1 = (screen_h - pad_1_size_y);
            }

            if(Console.KeyAvailable)
            {
                if(Input.GetKey(KeyCode.VK_UP) && posy_1 > 0)
                {
                    posy_1--;
                }

                if(Input.GetKey(KeyCode.VK_DOWN) && posy_1 < (screen_h - pad_1_size_y))
                {
                    posy_1++;
                }
            }
        }
        static void ControlPad2()
        {
            if(posy_2 < 1)
            {
                posy_2 = 0;
            }
            if(posy_2 > (screen_h - pad_2_size_y) - 1)
            {
                posy_2 = (screen_h - pad_2_size_y);
            }

            if(Console.KeyAvailable)
            {
                if(Input.GetKey(KeyCode.W) && posy_2 > 0)
                {
                    posy_2--;
                }

                if(Input.GetKey(KeyCode.S) && posy_2 < (screen_h - pad_2_size_y))
                {
                    posy_2++;
                }
            }
        }

        static void Main(string[] args)
        {
            Rect r1 = new Rect(pad_1_size_x, pad_1_size_y, ']');
            Rect r2 = new Rect(pad_2_size_x, pad_2_size_y, '[');
            r1.Draw(posx_1, posy_1);
            r2.Draw(posx_2, posy_2);
            //Game loop
            while (true)
            {
                ControlPad1();
                ControlPad2();

                Console.Clear();
                r1.Draw(posx_1, posy_1);
                r2.Draw(posx_2, posy_2);
                Thread.Sleep(60);
            }
        }
    }
}