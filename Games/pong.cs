using System;
using System.Threading;
using CONTROL;
using GEOM;
using COL;

namespace PONG
{
    class Program
    {
            //Geral --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            static int screen_h = Sys.GetWindowH();
            static int screen_w = Sys.GetWindowW();
            static Random rand = new Random();
            static bool pmode2 = false;
            static int random_color = rand.Next(0, 16);

            //Pad 1 --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            static int pad_1_size_y = 6;
            static int pad_1_size_x = 3;
            static int pad1_speed = 1;
            static int posx_1 = screen_w - pad_1_size_x;
            static int posy_1 = (screen_h/2) - (pad_1_size_y/2);
            static int pad1_pts = 0;

            
            //Pad 2 --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            static int pad_2_size_y = 6;
            static int pad_2_size_x = 3;
            static int pad2_speed = 1;
            static int posx_2 = 0;
            static int posy_2 = (screen_h/2) - (pad_2_size_y/2);
            static int pad2_pts = 0;

            //Ball --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            static int posx_ball = screen_w/2;
            static int posy_ball = screen_h/2;
            static int ball_dir_up = rand.Next(0, 2);
            static int ball_dir_right = rand.Next(0, 2);
            static int ball_speed = 1; 

        static void ControlPad1()
        {
            if(Console.KeyAvailable)
            {
                if(Input.GetKey(KeyCode.VK_UP) && posy_1 > 0)
                {
                    posy_1 -= pad1_speed;
                }

                if(Input.GetKey(KeyCode.VK_DOWN) && posy_1 < (screen_h - pad_1_size_y) - 1)
                {
                    posy_1 += pad1_speed;
                }
            }
        }
        static void ControlPad2()
        {
            if(Console.KeyAvailable)
            {
                if(Input.GetKey(KeyCode.W) && posy_2 > 0)
                {
                    posy_2 -= pad2_speed;
                }

                if(Input.GetKey(KeyCode.S) && posy_2 < (screen_h - pad_2_size_y) - 1)
                {
                    posy_2 += pad2_speed;
                }
            }
        }

        static void BallControl()
        {
            if (posy_ball == 0)
            {
                System.Media.SystemSounds.Beep.Play();
                ball_dir_up = 0;
            }
            if (posy_ball == Console.WindowHeight - 4)
            {
                System.Media.SystemSounds.Beep.Play();
                ball_dir_up = 1;
            }

            if(Collider.IsColiding(posx_ball, screen_w - 6))
            {
                System.Media.SystemSounds.Exclamation.Play();
                pad1_pts++;
                ResetBall();
                ResetPads();
            }
            
            if(Collider.IsColiding(posx_ball, 0))
            {
                System.Media.SystemSounds.Question.Play();
                pad2_pts++;
                ResetBall();
                ResetPads();
            }

            if (Collider.IsColiding(posx_ball, posx_2 + pad_2_size_x + 1, 2))
            {
                if (Collider.IsColiding(posy_ball, posy_2 - 1, 3) && Collider.IsColiding(posy_ball, posy_2 + pad_2_size_y, 1))
                {
                    System.Media.SystemSounds.Hand.Play();
                    random_color = rand.Next(0, 16);
                    Sys.RemoveScrollBars((Sys.ColorCode)random_color);
                    ball_dir_right = 1;
                }
            }

            if(Collider.IsColiding(posx_ball, posx_1 - pad_1_size_x - 4, 4))
            {
                if(Collider.IsColiding(posy_ball, posy_1 - 1, 3) && Collider.IsColiding(posy_ball, posy_1 + pad_1_size_y, 1))
                {
                    System.Media.SystemSounds.Hand.Play();
                    random_color = rand.Next(0, 16);
                    Sys.RemoveScrollBars((Sys.ColorCode)random_color);
                    ball_dir_right = 0;
                }
            }

            if (ball_dir_up == 1)
            {
                posy_ball -= ball_speed;
            }
            else
            {
                posy_ball += ball_speed;
            }


            if (ball_dir_right == 1)
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
            Thread.Sleep(1000);
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
            int random_num = rand.Next(1, 101);
            if (random_num <= 70)
            {
                if (ball_dir_up == 1 && posy_1 > 1)
                {
                    posy_1 -= pad1_speed;
                }
                else if (ball_dir_up == 0 && (posy_1 + pad_1_size_y) != screen_h)
                {
                    posy_1 += pad1_speed;
                }
            }
        }
        static public void ResetPads()
        {
            posx_1 = screen_w - pad_1_size_x;
            posy_1 = (screen_h/2) - (pad_1_size_y/2);
            posx_2 = 0;
            posy_2 = (screen_h/2) - (pad_2_size_y/2);
        }

        static public void ResetAll()
        {
            ResetBall();
            ResetPads();
            ball_dir_up = rand.Next(0, 2);
            ball_dir_right = rand.Next(0, 2);
            pad1_pts = 0;
            pad2_pts = 0;
        }

        static void Main(string[] args)
        {
            Rect r1 = new Rect(pad_1_size_x, pad_1_size_y, ']');
            Rect r2 = new Rect(pad_2_size_x, pad_2_size_y, '[');
            Circle c = new Circle(1, '*');
            r1.Draw(posx_1, posy_1);
            r2.Draw(posx_2, posy_2);
            c.Draw(screen_w/2, screen_h/2);

            Sys.RemoveScrollBars((Sys.ColorCode)random_color);

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
                c.Draw(posx_ball, posy_ball);
                DrawResult();
                Thread.Sleep(60);
            }
        }
    }
}