using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23_11
{
    class SequentialTrafficLights:TrafficLight
    {
        private int lastGreen;
        public SequentialTrafficLights(Junction j) : base(j)
        {
            lastGreen = 0;
        }

        public override void ChangeLight()
        {
            _currentGreen = ++lastGreen % _junction.GetEntringRoad.Count;
            Console.WriteLine(this);
        }
        public override string ToString()
        {
            return $"Sequential TrafficLights junction {_junction}, delay= {_delay}, Green light on {GetCurrentGreen()}";
        }
    }
}
