using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23_11
{
    class Map
    {
        private List<Junction> _junctions = new List<Junction>();
        private List<Road> _roads = new List<Road>();
        private static Random rnd = new Random();
        public Map(int n)
        {
            for(int i = 1; i <= n; i++)
            {
                Junction j = new Junction();
                _junctions.Add(j);
            }
            for(int i = 0; i < _junctions.Count - 1; i++)
            {
                for(int j = 0; j < _junctions.Count - 1; j++)
                {
                    if(i != j && rnd.Next(2)==1)
                    {
                        Road r = new Road(_junctions.ElementAt(i), _junctions.ElementAt(j));
                        _roads.Add(r);
                    }
                }
            }
            AddTrafficLight();
        }

        public Map(List<Junction> junctions,List<Road> roads)
        {
            _junctions = junctions;
            _roads = roads;
            AddTrafficLight();
        }

        public List<Junction> Junctions
        {
            get => this._junctions;
        }
        public void AddTrafficLight()
        {
            for(int i = 0; i < _junctions.Count - 1; i++)
            {
                if (_junctions.ElementAt(i).GetEntringRoad.Count > 0)
                {
                    if (rnd.Next(4) == 1)
                    {
                        if (rnd.Next(2) == 1)
                            _junctions.ElementAt(i).Traffic = new RandomTraficLights(_junctions.ElementAt(i));
                        else
                            _junctions.ElementAt(i).Traffic = new SequentialTrafficLights(_junctions.ElementAt(i));
                    }
                }
            }
        }

        public List<Road> RandomMap()
        {
            Junction junc = _junctions.ElementAt(rnd.Next(_junctions.Count));
            while (junc.GetExitingRoad.Count == 0)
            {
                junc = _junctions.ElementAt(rnd.Next(_junctions.Count));
            }
            List<Road> roads = new List<Road>();
            while(roads.Count<4 && junc.GetExitingRoad.Count != 0)
            {
                roads.Add(junc.GetExitingRoad.ElementAt(rnd.Next(junc.GetExitingRoad.Count)));
                junc = roads.ElementAt(roads.Count - 1).End;
            }

            return roads;
        }
    }
}
