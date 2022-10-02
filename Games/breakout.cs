using System;
using System.Threading;
using CONTROL;
using GEOM;
using COL;

namespace BREAKOUT
{
    class prog
    {
        //Geral --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        static int screen_h = Sys.GetWindowH();
        static int screen_w = Sys.GetWindowW();
        static int state = 0;


        //Menu --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        static int select = 1;

        static public void DrawMenu()
        {
            //Texto
            /*
            _______  ______    _______  _______  ___   _  _______  __   __  _______ 
            |  _    ||    _ |  |       ||   _   ||   | | ||       ||  | |  ||       |
            | |_|   ||   | ||  |    ___||  |_|  ||   |_| ||   _   ||  | |  ||_     _|
            |       ||   |_||_ |   |___ |       ||      _||  | |  ||  |_|  |  |   |  
            |  _   | |    __  ||    ___||       ||     |_ |  |_|  ||       |  |   |  
            | |_|   ||   |  | ||   |___ |   _   ||    _  ||       ||       |  |   |  
            |_______||___|  |_||_______||__| |__||___| |_||_______||_______|  |___| 
            */
            int[] colors = {5, 12, 14, 10, 11, 9};
            string[] s = {"_______  ______    _______  _______  ___   _  _______  __   __  _______ ", "|  _    ||    _ |  |       ||   _   ||   | | ||       ||  | |  ||       |","| |_|   ||   | ||  |    ___||  |_|  ||   |_| ||   _   ||  | |  ||_     _|",
             "|       ||   |_||_ |   |___ |       ||      _||  | |  ||  |_|  |  |   |  ","|  _   | |    __  ||    ___||       ||     |_ |  |_|  ||       |  |   |  ", "|_______||___|  |_||_______||__| |__||___| |_||_______||_______|  |___| "};
            for(int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(screen_w/2 - 50, i);
                Console.ForegroundColor = (System.ConsoleColor)colors[i];
                Console.Write(s[i]);
            }
            Console.ForegroundColor = (System.ConsoleColor)Sys.ColorCode.White;
            Console.SetCursorPosition(screen_w/2 - 25, 7);
            Console.Write("Selecione o level");
            DrawNumbers();
        }

        static void DrawNumbers()
        {
            /*
             #  
            ##  
             #  
             #  
            ###
            /// 
            ### 
              # 
            ### 
            #   
            ###
            ///
            ### 
              # 
             ## 
              # 
            ###
            */
            int offset = 35;
            int[] colors = {10, 12, 11};
            string[] n1 = {" #", "##", " #", " #", "###"};
            string[] n2 = {"###", "  #", "###", "#  ", "###"};
            string[] n3 = {"###","  #"," ##", "  #", "###"};
            for(int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(screen_w/2 - offset, 9+i);
                Console.ForegroundColor = (System.ConsoleColor)colors[0];
                Console.Write(n1[i]);
            }
            offset -= 20;
            for(int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(screen_w/2 - offset, 9+i);
                Console.ForegroundColor = (System.ConsoleColor)colors[1];
                Console.Write(n2[i]);
            }
            offset -= 20;
            for(int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(screen_w/2 - offset, 9+i);
                Console.ForegroundColor = (System.ConsoleColor)colors[2];
                Console.Write(n3[i]);
            }
        }
        static int ControlMenu()
        {
            /*
            ##   
             #|  
              || 
             #|  
            ##
            */
            string selector = "||->";
            int[] colors = {10, 12, 11};
            int offset = 35, distance = 8;

            if(Input.GetKey(KeyCode.VK_RIGHT))
            {
                if(select < 3)
                {
                    select++;
                }
            }

            if(Input.GetKey(KeyCode.VK_LEFT))
            {
                if(select > 1)
                {
                    select--;
                }
            }
            switch (select)
            {
                case 1:
                    Console.ForegroundColor = (System.ConsoleColor)colors[0];
                    break;
                case 2:
                    offset -= 20; 
                    Console.ForegroundColor = (System.ConsoleColor)colors[1];
                    break;
                case 3:
                    offset -= 40; 
                    Console.ForegroundColor = (System.ConsoleColor)colors[2];
                    break;
            }
            Console.SetCursorPosition(screen_w/2 - offset - distance, 11);
            Console.Write(selector);
            
            if(Input.GetKey(KeyCode.VK_RETURN))
            {
                return select;
            }
            return 0;
        }

        static void Main()
        {
            Sys.RemoveScrollBars();
            while(true)
            {
                Console.Clear();
                DrawMenu();
                state = ControlMenu();

                switch(state)
                {
                    default:
                        break;
                    case 1:
                        Console.Write("Load level 1");
                        break;
                    case 2:
                        Console.Write("Load level 2");
                        break;
                    case 3:
                        Console.Write("Load level 3");
                        break;

                }
                Thread.Sleep(60);
            }
        }
    }
}