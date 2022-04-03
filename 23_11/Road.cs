using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23_11
{
    class Road
    {
        private Junction _start;
        private Junction _end;

        public Junction Start
        {
            get => _start;
        }
        public Junction End
        {
            get => _end;
        }
        public Road(Junction start,Junction end)
        {
            _start = start;
            _end = end;
            if (start == end)
            {
                _end = new Junction();
                Console.WriteLine($"Road can not connect a junction to itself, the end junction has been replaced with Junction {_end.Id}");
            }
            _start.AddExitingRoad(this);
            _end.AddEnteringRoad(this);

            Console.WriteLine($"Creating {this}");
        }

        public double GetLength()
        {
            return _start.calcDistance(_end);
        }

        public override string ToString()
        {
            return $"Road from {_start.Id} to {_end.Id} , length: {GetLength():f2}";
        }
    }
}
