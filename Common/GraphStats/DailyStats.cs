using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.GraphStats
{
 
    public class DailyStats
    {
        public int MaxDays = 250;
        public LinkedList<double> Days = new LinkedList<double>();
        public LinkedList<double> Entities = new LinkedList<double>();
        public LinkedList<double> Food = new LinkedList<double>();
        public IEnumerable<double> Speed = new LinkedList<double>();

        public DailyStats()
        {
            Days.AddFirst(0);
            Entities.AddFirst(0);
            Food.AddFirst(0);
        }

        public void Update(int day, int entityCount = 0, int foodCount = 0, IEnumerable<double> speedList = null)
        {
            Days.AddLast(day);
            Entities.AddLast(entityCount);
            Food.AddLast(foodCount);
            Speed = speedList;

            if (Days.Count > MaxDays)
            {
                Days.RemoveFirst();
                Entities.RemoveFirst();
                Food.RemoveFirst();
            }
        }
    }
}
