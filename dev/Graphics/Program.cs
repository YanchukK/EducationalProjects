using NConsoleGraphics;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painting
{
    class Rectangle
    {
        private uint color;
        private int x, y, w, h;

        public Rectangle(uint color, int x, int y, int w, int h)
        {
            this.color = color;
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }

        public void Render(ConsoleGraphics graphics)
        {
            graphics.FillRectangle(color, x, y, w, h);
        }

        public void Update(ConsoleGraphics graphics)
        {
            x++;
            y--;

            //if (y < graphics.ClientHeight - h)
            //{
            //    x++;
            //    y++;
            //}
            //else
            //{

            //    //while (y != 0)
            //    //{
            //    //    x++;
            //    //    y--;
            //    //}
            //}
        }

        private void Update2()
        {
            x++;
            y--;
        }

        private void Update2()
        {
            x++;
            y--;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            ConsoleGraphics graphics = new ConsoleGraphics();

            Rectangle r = new Rectangle(0xFFFF0000, 0, graphics.ClientHeight, 100, 100);

            while (true)
            {
                graphics.FillRectangle(0xFFFFFFFF, 0, 0, graphics.ClientWidth, graphics.ClientHeight);

                //y = graphics.ClientHeight;
                //x = graphics.ClientWidth;

                r.Update(graphics);

                r.Render(graphics);

                graphics.FlipPages();
                Thread.Sleep(10);
            }

           
        }
    }
}
