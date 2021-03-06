using System;
using System.Collections.Generic;
using System.Threading;

namespace SnakeOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            int score = 0;
            Walls walls = new Walls(80, 25);
            walls.Draw();

            
            Point snakeTail = new Point(15, 15, 'o');
            Snake snake = new Snake(snakeTail, 5, Direction.RIGHT);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            snake.Draw();

            
            FoodGenerator foodGenerator = new FoodGenerator(80, 25, '*');
            Point food = foodGenerator.GenerateFood();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            food.Draw();


            while (true)
            {
                if(walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }

                if (snake.Eat(food))
                {
                    food = foodGenerator.GenerateFood();
                    food.Draw();
                    score++;
                }
                else
                {
                    snake.Move();
                }

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKeys(key.Key);
                }

                Thread.Sleep(250);
            }

            string str_score = Convert.ToString(score);
            WriteGameOver(str_score);
            Console.ReadLine();
        }

        public static void WriteGameOver(string score)
        {
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("=================", xOffset, yOffset++);
            WriteText("    GAME OVER   ", xOffset+1, yOffset++);
            yOffset++;
            WriteText($"You scored {score} points", xOffset + 2, yOffset++);
            WriteText("", xOffset+1, yOffset++);
            WriteText("=================", xOffset, yOffset++);
            Console.Beep(50, 1000);
        }

        public static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
    }
}
