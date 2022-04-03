using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23_11
{
    abstract class TrafficLight
    {
        protected Junction _junction;
        protected int _delay;
        protected int _currentGreen = 0;
        protected static Random rnd = new Random();
        private int _turns = 0;
        public TrafficLight(Junction junction)
        {
            _junction = junction;
            _delay = rnd.Next(3) + 2;
            Console.WriteLine($"Creating {this}");
        }

        public abstract void ChangeLight();

        public void Check()
        {
            if (++_turns % _delay == 0)
                ChangeLight();
        }
        public Road GetCurrentGreen()
        {
            return _junction.GetEntringRoad.ElementAt(_currentGreen);
        }

    }
}
