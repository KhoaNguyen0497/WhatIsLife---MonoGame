using ScottPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsManager.Graph
{
    public class DistributionGraphContainer : BaseGraphContainer
    {
        public Func<double[]> DataGetter;
        public float XMin, XMax;
        public int Bins;
        public override void Initiate()
        {
            Graph.Plot.SetAxisLimits(XMin, XMax, 0, 100);


            base.Initiate();
        }

        public override void Render()
        {
            var ticks = (XMax - XMin) / Bins;
            var data = DataGetter.Invoke();
            var graphData = new Dictionary<double, double>();
            foreach(var item in data)
            {
                var key = Math.Round(item / ticks,1);
                if (graphData.ContainsKey(key))
                {
                    graphData[key] += 1;
                }
                else
                {
                    graphData.Add(key, 1);
                }
            }

            var orderedItems = graphData.OrderBy(x=>x.Key).ToList();
            var xData = orderedItems.Select(x=>x.Key*ticks).ToArray();
            var yData = orderedItems.Select(x=>x.Value).ToArray();
            Plot.Update(xData, yData);
            Graph.Render();
            if (RenderCondition.Invoke())
            {
                
            }
        }
    }
}
