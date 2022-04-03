using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23_11
{
    class Point
    {
        protected int _x;
        protected int _y;
        private static Random rnd = new Random();

        public Point()
        {
            _x = rnd.Next(800);
            _y = rnd.Next(600);
        }

        public Point(int x,int y)
        {
            Correct_X_Y(ref x, ref y);
            _x = x;
            _y = y;
        }

        public void Correct_X_Y(ref int x,ref int y)
        {
            if (x < 0 || x > 800)
                x = rnd.Next(800);
            if (y < 0 || y > 600)
                x = rnd.Next(600);
        }

        public double calcDistance(Point other)
        {
            return Math.Sqrt(Math.Pow(_x - other._x, 2) + Math.Pow(_y - other._y, 2));
        }


        

    }
}
