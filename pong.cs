using System;
using System.Threading;
using CONTROL;
using GEOM;
using COL;

namespace PONG
{
    class Program
    {
            //Geral
            static int screen_h = Sys.GetWindowH();
            static int screen_w = Sys.GetWindowW();
            static Random randomGenerator = new Random();
            static bool pmode2 = false;

            //Pad 1
            static int pad_1_size_y = 6;
            static int pad_1_size_x = 3;
            static int pad1_speed = 1;
            static int posx_1 = screen_w - pad_1_size_x;
            static int posy_1 = (screen_h/2) - (pad_1_size_y/2);
            static int pad1_pts = 0;

            
            //Pad 2
            static int pad_2_size_y = 6;
            static int pad_2_size_x = 3;
            static int pad2_speed = 1;
            static int posx_2 = 0;
            static int posy_2 = (screen_h/2) - (pad_2_size_y/2);
            static int pad2_pts = 0;

            //Ball
            static int posx_ball = screen_w/2;
            static int posy_ball = screen_h/2;
            static bool ball_dir_up = true;
            static bool ball_dir_right = true;
            static int ball_speed = 1; 

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
                    posy_1 -= pad1_speed;
                }

                if(Input.GetKey(KeyCode.VK_DOWN) && posy_1 < (screen_h - pad_1_size_y))
                {
                    posy_1 += pad1_speed;
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
                    posy_2 -= pad2_speed;
                }

                if(Input.GetKey(KeyCode.S) && posy_2 < (screen_h - pad_2_size_y))
                {
                    posy_2 += pad2_speed;
                }
            }
        }

        static void BallControl()
        {
            if (posy_ball == 0)
            {
                ball_dir_up = false;
            }
            if (posy_ball == Console.WindowHeight - 3)
            {
                ball_dir_up = true;
            }

            if(Collider.IsColiding(posx_ball, screen_w - 1))
            {
                pad1_pts++;
                ResetBall();
            }
            
            if(Collider.IsColiding(posx_ball, 0))
            {
                pad2_pts++;
                ResetBall();
            }

            if (Collider.IsColiding(posx_ball, posx_2 + pad_2_size_x + 1, 2))
            {
                if (Collider.IsColiding(posy_ball, posy_2, 3) && Collider.IsColiding(posy_ball, posy_2 + pad_2_size_y, 1))
                {
                    ball_dir_right = true;
                }
            }

            if(Collider.IsColiding(posx_ball, posx_1 - pad_1_size_x - 1, 4))
            {
                if(Collider.IsColiding(posy_ball, posy_1, 3) && Collider.IsColiding(posy_ball, posy_1 + pad_1_size_y, 1))
                {
                    ball_dir_right = false;
                }
            }

            if (ball_dir_up)
            {
                posy_ball -= ball_speed;
            }
            else
            {
                posy_ball += ball_speed;
            }


            if (ball_dir_right)
            {
                posx_ball += ball_speed;
            }
            else
            {
                posx_ball -= ball_speed;
            }
        }

        public static void ResetBall()
        {
            posx_ball = screen_w/2;
            posy_ball = screen_h/2;
            Thread.Sleep(100);
        }

        static void DrawResult()
        {
            if(pmode2 == false)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 14, 1);
                Console.Write("Pressione 'p' para multiplayer");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 16, 2);
                Console.Write("Pressione 'r' para resetar o jogo");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 1, 0);
                Console.Write("{0}-{1}", pad1_pts, pad2_pts);
            }
            else
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 10, 1);
                Console.Write("Pressione 'p' para bot");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 16, 2);
                Console.Write("Pressione 'r' para resetar o jogo");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 1, 0);
                Console.Write("{0}-{1}", pad1_pts, pad2_pts);
            }
        }

        static void AISecondP()
        {
            int randomNumber = randomGenerator.Next(1, 101);
            if (randomNumber <= 70)
            {
                if (ball_dir_up == true && posy_1 > 1)
                {
                    posy_1 -= pad1_speed;
                }
                else if (ball_dir_up == false && (posy_1 + pad_1_size_y) != screen_h)
                {
                    posy_1 += pad1_speed;
                }
            }
        }

        static public void ResetAll()
        {
            ResetBall();
            posx_1 = screen_w - pad_1_size_x;
            posy_1 = (screen_h/2) - (pad_1_size_y/2);
            pad1_pts = 0;
            posx_2 = 0;
            posy_2 = (screen_h/2) - (pad_2_size_y/2);
            pad2_pts = 0;
        }

        static void Main(string[] args)
        {
            Rect r1 = new Rect(pad_1_size_x, pad_1_size_y, ']');
            Rect r2 = new Rect(pad_2_size_x, pad_2_size_y, '[');
            Triangle t = new Triangle('e', 2, '*');
            r1.Draw(posx_1, posy_1);
            r2.Draw(posx_2, posy_2);
            t.Draw(screen_w/2, screen_h/2);

            Sys.RemoveScrollBars(Sys.ColorCode.DarkGreen);

            //Game loop
            while (true)
            {
                ControlPad2();
                if(Input.GetKey(KeyCode.P))
                {
                    pmode2 = !pmode2;
                }
                if(Input.GetKey(KeyCode.R))
                {
                    ResetAll();
                }
                
                if(pmode2 == true)
                {
                    ControlPad1();
                }
                else
                {
                    AISecondP();
                }
                BallControl();

                Console.Clear();
                r1.Draw(posx_1, posy_1);
                r2.Draw(posx_2, posy_2);
                t.Draw(posx_ball, posy_ball);
                DrawResult();
                Thread.Sleep(60);
            }
        }
    }
}