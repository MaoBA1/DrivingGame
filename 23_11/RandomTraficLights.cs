using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23_11
{
    class RandomTraficLights:TrafficLight
    {
        public RandomTraficLights(Junction j) : base(j)
        {

        }

        public override void ChangeLight()
        {
            _currentGreen = rnd.Next(_junction.GetEntringRoad.Count);
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return $"Random TrafficLights junction {_junction}, delay= {_delay}, Green light on {GetCurrentGreen()}";
        }
    }
}
