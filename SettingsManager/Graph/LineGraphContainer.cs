using Common;
using ScottPlot;
using ScottPlot.Plottable;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsManager.Graph
{
    public class LineGraphContainer : BaseGraphContainer
    {
        public Func<double[]> XDataGetter, YDataGetter;

        public override void Initiate()
        {

            var legend = Graph.Plot.Legend();
            legend.Location = Alignment.UpperLeft;
            legend.FontSize = 22;

            base.Initiate();                   
        }

        public override void Render()
        {
            var xData = XDataGetter.Invoke();
            var yData = YDataGetter.Invoke();
            var yMax = Math.Max(yData.Max(), 1);
            if (RenderCondition.Invoke())
            {
                Plot.Update(xData, yData);
                Graph.Plot.SetAxisLimits(xData.First(), xData.Last() + 1, 0, yMax * 1.3);
                Graph.Render();
            }
        }
    }
}
