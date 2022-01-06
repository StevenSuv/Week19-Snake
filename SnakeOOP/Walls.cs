using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeOOP
{
    class Walls
    {
        List<Figure> wallList;

        public Walls(int mapWidth, int mapHeight)
        {
            wallList = new List<Figure>();
            HorizontalLine top = new HorizontalLine(0, 80, 0, '-');
            VerticalLine left = new VerticalLine(0, 25, 0, '|');
            HorizontalLine bottom = new HorizontalLine(0, 80, 25, '-');
            VerticalLine right = new VerticalLine(0, 25, 80, '|');

            VerticalLine obstacle = new VerticalLine(10, 14, 50, '|');
            VerticalLine obstacle2 = new VerticalLine(5, 8, 25, '|');
            VerticalLine obstacle3 = new VerticalLine(1, 3, 65, '|');
            VerticalLine obstacle4 = new VerticalLine(20, 23, 10, '|');
            VerticalLine obstacle5 = new VerticalLine(21, 24, 75, '|');
            VerticalLine obstacle6 = new VerticalLine(20, 23, 10, '|');
            Console.ForegroundColor = ConsoleColor.DarkGray;

            wallList.Add(top);
            wallList.Add(left);
            wallList.Add(bottom);
            wallList.Add(right);
            wallList.Add(obstacle);
            wallList.Add(obstacle2);
            wallList.Add(obstacle3);
            wallList.Add(obstacle4);
            wallList.Add(obstacle5);
            wallList.Add(obstacle6);
        }

        public void Draw()
        {
            foreach(var wall in wallList)
            {
                wall.Draw();
            }
        }

        public bool IsHit(Figure figure)
        {
            foreach(var wall in wallList)
            {
                if(wall.IsHit(figure))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
