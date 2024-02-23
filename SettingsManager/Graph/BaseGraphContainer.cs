using ScottPlot.Plottable;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SettingsManager.Graph
{
    public abstract class BaseGraphContainer
    {
        public FormsPlot Graph;
        protected ScatterPlot Plot;
        public Func<bool> RenderCondition;
        public string XLabel, YLabel, Label;

        public abstract void Render();
        public virtual void Initiate()
        {
            Plot = Graph.Plot.AddScatter([0], [0], label: Label);

            //Graph.Plot.Style(figureBackground: Color.SkyBlue);
            Plot.MarkerShape = MarkerShape.none;

            Graph.Configuration.Pan = false;
            Graph.Configuration.Zoom = false;

            float tickSize = 25f;
            Graph.Plot.YAxis.TickLabelStyle(fontSize: tickSize, color: Color.DarkGray);
            Graph.Plot.XAxis.TickLabelStyle(fontSize: tickSize, color: Color.DarkGray);

            Graph.Plot.XAxis.Label(label: XLabel, size: tickSize);
            Graph.Plot.YAxis.Label(label: YLabel, size: tickSize);

            Graph.Plot.YAxis.Layout(minimumSize: 80, maximumSize: 80);
            Graph.Plot.XAxis.Layout(minimumSize: 72, maximumSize: 72);

            Graph.Render();
        }

    }
}
