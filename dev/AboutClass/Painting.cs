using NConsoleGraphics;
using System;
using System.Threading;
using NConsoleGraphics;
using System.Drawing;

namespace Painting
{
    class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public int X { get; }
        public int Y { get; }
    }

    class Line
    {
        private readonly Point start, end;
        private readonly uint color;
        private readonly float thickness;

        public Line(Point start, Point end, uint color, float thickness = 7)
        {
            this.start = start;
            this.end = end;
            this.color = color;
            this.thickness = thickness;
        }

        public void Render(ConsoleGraphics graphics)
        {
            graphics.DrawLine(color, start.X, start.Y, end.X, end.Y, thickness);
        }
    }


    class Cross
    {
        private readonly Line[] lines;

        public Cross()
        {
            lines = new Line[2]
            {
                new Line(new Point(0, 0), new Point(100, 100), 0xFF00FF00),
                new Line(new Point(0, 100), new Point(100, 0), 0xFF00FF00)
            };
        }

        public void Render(ConsoleGraphics graphics)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i].Render(graphics);
            }
        }
    }

    class Field
    {
        private readonly Line[] lines;

        public Field()
        {
            lines = new Line[4]
            {
                new Line(new Point(100, 0), new Point(100, 300), 0xFF00FF00),
                new Line(new Point(200, 0), new Point(200, 300), 0xFF00FF00),
                new Line(new Point(0, 100), new Point(300, 100), 0xFF00FF00),
                new Line(new Point(0, 200), new Point(300, 200), 0xFF00FF00)
            };
        }

        public void Render(ConsoleGraphics graphics)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i].Render(graphics);
            }
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            ConsoleGraphics graphics = new ConsoleGraphics();

            Field field = new Field();
            Cross cross = new Cross();

            while (true)
            {
                graphics.FillRectangle(0xFFFFFFFF, 0, 0, graphics.ClientWidth, graphics.ClientHeight);
                //graphics.DrawString("0", drawFont, 0xFF00FF00, 200, 500);
                field.Render(graphics);
                if (Input.IsMouseLeftButtonDown)
                {
                    cross.Render(graphics);
                }

                graphics.FlipPages();
                //Thread.Sleep(50);
            }
        }
    }
}
