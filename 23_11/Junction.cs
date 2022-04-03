using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23_11
{
    class Junction:Point
    {
        private int _id;
        private static int _counter = 0;
        protected List<Road> _exitRoads = new List<Road>();
        protected List<Road> _enterRoads = new List<Road>();
        private TrafficLight _traffic;

        public int Id
        {
            get => _id;
        }
        public Junction(int x,int y):base(x,y)
        {
            _id = ++_counter;
            Console.WriteLine($"Creating Junction {_id} at {this}");
        }

        public Junction()
        {
            _id = ++_counter;
            new Point();
            Console.WriteLine($"Creating Junction {this} at point ({this._x},{this._y})");
        }

        public List<Road> GetEntringRoad
        {
            get => _enterRoads;
        }
        public List<Road> GetExitingRoad
        {
            get => _exitRoads;
        }

        public TrafficLight Traffic
        {
            get => _traffic;
            set => _traffic=value;
        }

        public void AddExitingRoad(Road r) => _exitRoads.Add(r);

        public void AddEnteringRoad(Road r) => _enterRoads.Add(r);

        public override string ToString()
        {
            return $"{_id}";
        }
        

    }
}
