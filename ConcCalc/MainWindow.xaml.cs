using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConcCalc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        Dictionary<double, double> value;
        Chart graph;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Chart graph = FindName("MyWinformChart") as Chart;
            value = new Dictionary<double, double>();
            for (double i = 5; i < 10; i += 0.01)
                value.Add(i, Math.Pow(Math.E, i));

            Chart chart = FindName("MyWinformChart") as Chart;
            chart.DataSource = value;
            chart.Series["series"].XValueMember = "Key";
            chart.Series["series"].YValueMembers = "Value";
        }

        private void DrawAGraphAnalytic()
        {
            //Random Rand = new Random();
            //double Innacurate = 0;
            //graph.Series[0].Points.Clear();
            //graph.Series[1].Points.Clear();
            //graph.Series[2].Points.Clear();
            //graph.Series[3].Points.Clear();
            //graph.Series[4].Points.Clear();
            //graph.Series[5].Points.Clear();
            //double yA, yB = 0;
            //int skip_first = 0;
            
            //graph.Series[1].Points.AddXY(0, 0);
            //for (double i = 0; i < Convert.ToDouble(TimeForReaction.Value); i += Convert.ToDouble(TimeForReaction.Value) / 20)
            //{
            //    skip_first++;
            //    yA = Convert.ToDouble(ConcentrationOfA.Value) * Math.Pow(Math.E, i * (-1) * (Convert.ToDouble(ReactSpeedKOne.Value)));
            //    Innacurate = (yA / 100) * Rand.Next(Convert.ToInt32(MaximalInaccuracy.Value) - Convert.ToInt32(MinimalInaccuracy.Value), Convert.ToInt32(MaximalInaccuracy.Value));
            //    graph.Series[0].Points.AddXY(i, yA);
            //    graph.Series[3].Points.AddXY(i, yA + Innacurate);
            //    if (skip_first > 1)
            //    {
            //        yB = (Convert.ToDouble(ConcentrationOfA.Value) - yA) * Math.Pow(Math.E, i * (-1) * (Convert.ToDouble(ReactSpeedKTwo.Value)));
            //        graph.Series[1].Points.AddXY(i, yB);
            //        graph.Series[4].Points.AddXY(i, yB + Innacurate);
            //    }

            //    graph.Series[2].Points.AddXY(i, Convert.ToDouble(ConcentrationOfA.Value) - yA - yB);
            //    graph.Series[5].Points.AddXY(i, Convert.ToDouble(ConcentrationOfA.Value) - yA - yB + Innacurate);
            //}
        }
    }
}
