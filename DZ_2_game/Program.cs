using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApp41
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 1, y = 1, w = 41, h = 30, offsetX = 1, offsetY = 1, posX = 0, posY = 0, platformOfset = 1;
            Console.CursorVisible = false;
            for (int i = 0; i < h; i++)
            {
                for(int j = 0; j < w; j++)
                {
                    if (i == 0 || (j == 0 || j == w-1) || (i == h-1 && j < 10))
                    {
                        Console.Write("*");
                    } else
                    {
                        Console.Write(" ");
                    }
          
                    if (j == w-1)
                    {
                        Console.WriteLine("");
                    }
                }
            }

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Escape:
                            goto End;

                        case ConsoleKey.RightArrow:
                            {
                                if (platformOfset == w - 11)
                                {
                                    continue;
                                }
                                posX = x;
                                posY = y;
                                Console.CursorLeft = 0;
                                Console.CursorTop = 29;
                                platformOfset++;                          
                                for (int t = 0; t < w; t++)
                                {
                                    Console.Write(" ");
                                }
                                Console.CursorLeft = platformOfset;
                                for (int k = 0; k < 10; k++)
                                {
                                   Console.Write("*");
                                }

                                Console.CursorLeft = posX;
                                Console.CursorTop = posY;
                            }; break;

                        case ConsoleKey.LeftArrow:
                            {
                                if (platformOfset == 1)
                                {
                                    continue;
                                }
                                posX = x;
                                posY = y;
                                Console.CursorLeft = 0;
                                Console.CursorTop = 29;
                                platformOfset--;
                                for (int t = 0; t < w; t++)
                                {
                                    Console.Write(" ");
                                }
                                Console.CursorLeft = platformOfset;
                                for (int k = 0; k < 10; k++)
                                {
                                    Console.Write("*");
                                }

                                Console.CursorLeft = posX;
                                Console.CursorTop = posY;
                            }; break;
                    }

                }
                Console.CursorLeft = x;
                Console.CursorTop = y;
                Console.Write(' ');
                x += offsetX;
                y += offsetY;
                if (x < 1) { x = 1; offsetX = -offsetX; }
                if (x > 38) { x = 38; offsetX = -offsetX; }

                if (y < 1) { y = 1; offsetY = -offsetY; }
                if ((y == 28 && x >= platformOfset && x <= platformOfset + 10))
                {
                    y = 28; offsetY = -offsetY;
                }
                if (y > 29)
                {
                    goto End;
                }

                Console.CursorLeft = x;
                Console.CursorTop = y;
                Console.Write("Ѡ");
                Thread.Sleep(150);//пот ок, метод задерживает выполнение


            }
            End:;
        }
    }
}
