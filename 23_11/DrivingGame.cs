using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23_11
{
    class DrivingGame
    {
        private List<Vehicle> _vehicles = new List<Vehicle>();
        private List<TrafficLight> _trafficLight = new List<TrafficLight>();
        private Map _map;
        public DrivingGame(int junctionsCount,int vehicleCount)
        {
            _map = new Map(junctionsCount);
            for (int i = 0; i < vehicleCount; i++)
                _vehicles.Add(new Vehicle(_map));
            for (int k = 0; k < _map.Junctions.Count; k++)
                if (_map.Junctions.ElementAt(k).Traffic != null)
                    _trafficLight.Add(_map.Junctions.ElementAt(k).Traffic);
        }

        public void play(int turns)
        {
            for(int i = 0; i < turns; i++)
            {
                Console.WriteLine($"Turn {i + 1}");

                for (int j = 0; j < _vehicles.Count; j++)
                    _vehicles.ElementAt(j).move();
                for (int k = 0; k < _trafficLight.Count; k++)
                    _trafficLight.ElementAt(k).Check();
            }
        }

    }
}
