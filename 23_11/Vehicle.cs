using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23_11
{
    class Vehicle
    {
        private int _id;
        private static int _counter=0;
        private Map _map;
        private List<Road> _roads;
        private int _speed;
        private static Random rnd = new Random();
        private int _currentRoad = 0;
        private double _distance = 0;

        public Vehicle(Map map)
        {
            _id = ++_counter;
            _map = map;
            _roads = _map.RandomMap();
            _speed = rnd.Next(30, 120);
            Console.WriteLine($"Creating {this}");
        }

       public void move()
       {
            _distance += _speed;


            if (_distance >= _roads.ElementAt(_currentRoad).GetLength())
            {
                if (_currentRoad == _roads.Count - 1)
                {
                    Console.WriteLine($"Vehicle {_id} arrived to it's destination: junction {_roads.ElementAt(_currentRoad).End.Id}");
                    return;
                }
                else
                {
                    if (_roads[_currentRoad].Start.Traffic != null)
                    {
                        if (_roads[_currentRoad].Start.Traffic.GetCurrentGreen() != _roads[_currentRoad])
                        {
                            Console.WriteLine($"Vehicle {_id} is Wating on junction {_roads.ElementAt(_currentRoad + 1)} ...");
                            _distance = _roads[_currentRoad].GetLength();
                            return;

                        }
                    }
                       
                    _distance -= _roads.ElementAt(_currentRoad).GetLength();
                    _currentRoad++;
                }

            }
            Console.WriteLine($"Vehicle {_id} is moving on the Road from Junction {_roads.ElementAt(_currentRoad).Start.Id} to Junction {_roads.ElementAt(_currentRoad).End.Id}");
       }

        public override string ToString()
        {
            string path = "[";
            foreach (Road r in _roads)
                path +=$"{r},";
            path += ']';
            return $"Vehicle {_id},speed: {_speed},path: {path}";
        }
    }
}
