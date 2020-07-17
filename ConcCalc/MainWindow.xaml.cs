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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TableOfValuesDatagrid.EnableHeadersVisualStyles = false;
        }

        private void DrawAGraphAnalytic()
        {
            Random Rand = new Random();
            double Innacurate = 0;
            GraphOfValues.Series[0].Points.Clear();
            GraphOfValues.Series[1].Points.Clear();
            GraphOfValues.Series[2].Points.Clear();
            GraphOfValues.Series[3].Points.Clear();
            GraphOfValues.Series[4].Points.Clear();
            GraphOfValues.Series[5].Points.Clear();
            double yA, yB = 0;
            TableOfValuesDatagrid.RowCount = 21;
            TableOfValuesDatagrid.ColumnCount = 2;
            GraphOfValues.Series[1].Points.AddXY(0, 0);
            for (double i = 0; i < Convert.ToDouble(TimeForReaction.Value); i += Convert.ToDouble(TimeForReaction.Value) / 500)
            {

                yA = Convert.ToDouble(ConcentrationOfA.Value) * Math.Pow(Math.E, i * (-1) * (Convert.ToDouble(ReactSpeedKOne.Value)));
                Innacurate = (yA / 100) * Rand.Next(Convert.ToInt32(MaximalInaccuracy.Value) - Convert.ToInt32(MinimalInaccuracy.Value), Convert.ToInt32(MaximalInaccuracy.Value));
                GraphOfValues.Series[0].Points.AddXY(i, yA);
                GraphOfValues.Series[3].Points.AddXY(i, yA + Innacurate);
                yB = (Convert.ToDouble(ConcentrationOfA.Value) - yA) * Math.Pow(Math.E, i * (-1) * (Convert.ToDouble(ReactSpeedKTwo.Value)));
                GraphOfValues.Series[1].Points.AddXY(i, yB);
                GraphOfValues.Series[4].Points.AddXY(i, yB + Innacurate);
                GraphOfValues.Series[2].Points.AddXY(i, Convert.ToDouble(ConcentrationOfA.Value) - yA - yB);
                GraphOfValues.Series[5].Points.AddXY(i, Convert.ToDouble(ConcentrationOfA.Value) - yA - yB + Innacurate);
            }
        }

        private void DrawConcATableAnalytic()
        {
            try
            {
                double yA;
                TableOfValuesDatagrid.RowHeadersVisible = false;
                int CurrentRow = 0;
                TableOfValuesDatagrid.RowCount = Convert.ToInt32(TimeForReaction.Value * 10);
                TableOfValuesDatagrid.ColumnCount = 2;
                for (double i = 0; i <= Convert.ToDouble(TimeForReaction.Value); i += Convert.ToDouble(TimeForReaction.Value) / 20)
                {
                    yA = Convert.ToDouble(ConcentrationOfA.Value) * Math.Pow(Math.E, i * (-1) * Convert.ToDouble(ReactSpeedKOne.Value));
                    TableOfValuesDatagrid.Rows[CurrentRow].Cells[0].Value = Math.Round(i, 2);
                    TableOfValuesDatagrid.Rows[CurrentRow].Cells[1].Value = Math.Round(yA, 2);
                    CurrentRow++;



                }
                TableOfValuesDatagrid.Columns[0].HeaderText = "Value of x";
                TableOfValuesDatagrid.Columns[1].HeaderText = "Value of f(x)";
            }
            catch (Exception)
            {

            }
        }
        private void DrawConcBTableAnalytic()
        {
            try
            {
                double yA, yB = 0;
                TableOfValuesDatagrid.RowHeadersVisible = false;
                int CurrentRow = 0;

                TableOfValuesDatagrid.RowCount = Convert.ToInt32(TimeForReaction.Value * 10); ;
                TableOfValuesDatagrid.ColumnCount = 2;
                for (double i = 0; i <= Convert.ToDouble(TimeForReaction.Value); i += Convert.ToDouble(TimeForReaction.Value) / 20)
                {
                    yA = Convert.ToDouble(ConcentrationOfA.Value) * Math.Pow(Math.E, i * (-1) * Convert.ToDouble(ReactSpeedKOne.Value));
                    yB = (Convert.ToDouble(ConcentrationOfA.Value) - yA) * Math.Pow(Math.E, i * (-1) * Convert.ToDouble(ReactSpeedKTwo.Value));
                    TableOfValuesDatagrid.Rows[CurrentRow].Cells[0].Value = Math.Round(i, 2);
                    TableOfValuesDatagrid.Rows[CurrentRow].Cells[1].Value = Math.Round(yB, 2);
                    CurrentRow++;
                }
                TableOfValuesDatagrid.Columns[0].HeaderText = "Value of x";
                TableOfValuesDatagrid.Columns[1].HeaderText = "Value of f(x)";
            }
            catch (Exception)
            {

            }
        }
        private void DrawConcCTableAnalytic()
        {
            try
            {
                double yA, yB = 0;
                TableOfValuesDatagrid.RowHeadersVisible = false;
                int CurrentRow = 0;
                TableOfValuesDatagrid.RowCount = Convert.ToInt32(TimeForReaction.Value * 10); ;
                TableOfValuesDatagrid.ColumnCount = 2;
                for (double i = 0; i <= Convert.ToDouble(TimeForReaction.Value); i += Convert.ToDouble(TimeForReaction.Value) / 20)
                {
                    yA = Convert.ToDouble(ConcentrationOfA.Value) * Math.Pow(Math.E, i * (-1) * Convert.ToDouble(ReactSpeedKOne.Value));
                    yB = (Convert.ToDouble(ConcentrationOfA.Value) - yA) * Math.Pow(Math.E, i * (-1) * Convert.ToDouble(ReactSpeedKTwo.Value));
                    TableOfValuesDatagrid.Rows[CurrentRow].Cells[0].Value = Math.Round(i, 2);
                    TableOfValuesDatagrid.Rows[CurrentRow].Cells[1].Value = Math.Round(Convert.ToDouble(ConcentrationOfA.Value) - yB - yA, 2);
                    CurrentRow++;
                }
                TableOfValuesDatagrid.Columns[0].HeaderText = "Value of x";
                TableOfValuesDatagrid.Columns[1].HeaderText = "Value of f(x)";
            }
            catch (Exception)
            {

            }
        }


        private void AnalyticButton_Click(object sender, EventArgs e)
        {
            DrawAGraphAnalytic();
            if (ConcentrationAButton.IsChecked.Value)
            {
                TableOfValuesDatagrid.Rows.Clear();
                DrawConcATableAnalytic();
            }
            if (ConcentrationBButton.IsChecked.Value)
            {
                TableOfValuesDatagrid.Rows.Clear();
                DrawConcBTableAnalytic();
            }
            if (ConcentrationCButton.IsChecked.Value)
            {
                TableOfValuesDatagrid.Rows.Clear();
                DrawConcCTableAnalytic();
            }
        }

        private void EilerButton_Click(object sender, EventArgs e)
        {
            DrawAGraphEiler();
            if (ConcentrationAButton.IsChecked.Value)
            {
                TableOfValuesDatagrid.Rows.Clear();
                DrawConcATableEiler();
            }
            if (ConcentrationBButton.IsChecked.Value)
            {
                TableOfValuesDatagrid.Rows.Clear();
                DrawConcBTableEiler();
            }
            if (ConcentrationCButton.IsChecked.Value)
            {
                TableOfValuesDatagrid.Rows.Clear();
                DrawConcCTableEiler();
            }

        }

        private void DrawConcATableEiler()
        {
            try
            {
                tmpA = 0;
                double yA;
                TableOfValuesDatagrid.RowHeadersVisible = false;
                int CurrentRow = 0;
                bool SkipFirst = true;
                TableOfValuesDatagrid.RowCount = Convert.ToInt32(Convert.ToDouble(TimeForReaction.Value) / Convert.ToDouble(StepOfEiler.Value));
                TableOfValuesDatagrid.ColumnCount = 2;
                for (double i = 0; i <= Convert.ToDouble(TimeForReaction.Value); i += Convert.ToDouble(StepOfEiler.Value))
                {
                    if (SkipFirst)
                    {
                        yA = Convert.ToDouble(ConcentrationOfA.Value);
                        tmpA = yA;
                        SkipFirst = false;
                    }
                    else
                    {
                        yA = tmpA - Convert.ToDouble(StepOfEiler.Value) * Convert.ToDouble(ReactSpeedKOne.Value) * tmpA;
                        tmpA = yA;
                    }

                    TableOfValuesDatagrid.Rows[CurrentRow].Cells[0].Value = Math.Round(i, 2);
                    TableOfValuesDatagrid.Rows[CurrentRow].Cells[1].Value = Math.Round(yA, 2);
                    CurrentRow++;

                }
                TableOfValuesDatagrid.Columns[0].HeaderText = "Value of x";
                TableOfValuesDatagrid.Columns[1].HeaderText = "Value of f(x)";
            }
            catch (Exception)
            {

            }
        }
        private void DrawConcBTableEiler()
        {
            try
            {
                tmpA = 0;
                tmpB = 0;
                double yB, yA;
                TableOfValuesDatagrid.RowHeadersVisible = false;
                int CurrentRow = 0;
                bool SkipFirst = true;
                TableOfValuesDatagrid.RowCount = Convert.ToInt32(Convert.ToDouble(TimeForReaction.Value) / Convert.ToDouble(StepOfEiler.Value));
                TableOfValuesDatagrid.ColumnCount = 2;
                for (double i = 0; i <= Convert.ToDouble(TimeForReaction.Value); i += Convert.ToDouble(StepOfEiler.Value))
                {
                    if (SkipFirst)
                    {
                        yA = Convert.ToDouble(ConcentrationOfA.Value);
                        tmpA = yA;
                    }
                    else
                    {
                        yA = tmpA - Convert.ToDouble(StepOfEiler.Value) * Convert.ToDouble(ReactSpeedKOne.Value) * tmpA;
                        tmpA = yA;
                    }

                    if (SkipFirst)
                    {
                        yB = 0;
                        tmpB = yB;
                        SkipFirst = false;
                    }
                    else
                    {
                        yB = tmpB + Convert.ToDouble(StepOfEiler.Value) * (Convert.ToDouble(ReactSpeedKOne.Value) * tmpA - tmpB * Convert.ToDouble(ReactSpeedKTwo.Value));
                        tmpB = yB;
                    }

                    TableOfValuesDatagrid.Rows[CurrentRow].Cells[0].Value = Math.Round(i, 2);
                    TableOfValuesDatagrid.Rows[CurrentRow].Cells[1].Value = Math.Round(yB, 2);
                    CurrentRow++;
                }
                TableOfValuesDatagrid.Columns[0].HeaderText = "Value of x";
                TableOfValuesDatagrid.Columns[1].HeaderText = "Value of f(x)";
            }
            catch (Exception)
            {

            }
        }

        private void DrawConcCTableEiler()
        {
            try
            {
                tmpA = 0;
                tmpB = 0;
                double yA, yB;
                TableOfValuesDatagrid.RowHeadersVisible = false;
                int CurrentRow = 0;
                int SkipFirst = 0;
                TableOfValuesDatagrid.RowCount = Convert.ToInt32(Convert.ToDouble(TimeForReaction.Value) / Convert.ToDouble(StepOfEiler.Value));
                TableOfValuesDatagrid.ColumnCount = 2;
                for (double i = 0; i <= Convert.ToDouble(TimeForReaction.Value); i += Convert.ToDouble(StepOfEiler.Value))
                {
                    if (SkipFirst == 0)
                    {
                        yA = Convert.ToDouble(ConcentrationOfA.Value);
                        tmpA = yA;
                    }
                    else
                    {
                        yA = tmpA - Convert.ToDouble(StepOfEiler.Value) * Convert.ToDouble(ReactSpeedKOne.Value) * tmpA;
                        tmpA = yA;
                    }
                    if (SkipFirst == 0)
                    {
                        yB = 0;
                        tmpB = yB;
                        SkipFirst++;
                    }
                    else
                    {
                        yB = tmpB + Convert.ToDouble(StepOfEiler.Value) * (Convert.ToDouble(ReactSpeedKOne.Value) * tmpA - tmpB * Convert.ToDouble(ReactSpeedKTwo.Value));
                        tmpB = yB;
                    }

                    TableOfValuesDatagrid.Rows[CurrentRow].Cells[0].Value = Math.Round(i, 2);
                    TableOfValuesDatagrid.Rows[CurrentRow].Cells[1].Value = Math.Round(Convert.ToDouble(ConcentrationOfA.Value) - yA - yB, 2);
                    CurrentRow++;
                }
                TableOfValuesDatagrid.Columns[0].HeaderText = "Value of x";
                TableOfValuesDatagrid.Columns[1].HeaderText = "Value of f(x)";
            }
            catch (Exception)
            {

            }
        }
        double tmpA, tmpB;
        private void DrawAGraphEiler()
        {
            Random Rand = new Random();
            double Innacurate = 0;
            GraphOfValues.Series[0].Points.Clear();
            GraphOfValues.Series[1].Points.Clear();
            GraphOfValues.Series[2].Points.Clear();
            GraphOfValues.Series[3].Points.Clear();
            GraphOfValues.Series[4].Points.Clear();
            GraphOfValues.Series[5].Points.Clear();
            double yA, yB;
            bool SkipFirst = true;
            GraphOfValues.Series[1].Points.AddXY(0, 0);
            for (double i = 0; i < Convert.ToDouble(TimeForReaction.Value); i += Convert.ToDouble(StepOfEiler.Value))
            {

                if (SkipFirst)
                {
                    yA = Convert.ToDouble(ConcentrationOfA.Value);
                    tmpA = yA;
                    Innacurate = (yA / 100) * Rand.Next(Convert.ToInt32(MaximalInaccuracy.Value) - Convert.ToInt32(MinimalInaccuracy.Value), Convert.ToInt32(MaximalInaccuracy.Value));
                    GraphOfValues.Series[0].Points.AddXY(i, yA);
                    GraphOfValues.Series[3].Points.AddXY(i, yA + Innacurate);
                }
                else
                {
                    yA = tmpA - Convert.ToDouble(StepOfEiler.Value) * Convert.ToDouble(ReactSpeedKOne.Value) * tmpA;
                    tmpA = yA;
                    GraphOfValues.Series[0].Points.AddXY(i, yA);
                    GraphOfValues.Series[3].Points.AddXY(i, yA + Innacurate);
                }

                if (SkipFirst)
                {
                    yB = 0;
                    tmpB = yB;
                    GraphOfValues.Series[1].Points.AddXY(i, yB);
                    GraphOfValues.Series[4].Points.AddXY(i, yB + Innacurate);
                }
                else
                {
                    yB = tmpB + Convert.ToDouble(StepOfEiler.Value) * (Convert.ToDouble(ReactSpeedKOne.Value) * yA - tmpB * Convert.ToDouble(ReactSpeedKTwo.Value));
                    tmpB = yB;
                    GraphOfValues.Series[1].Points.AddXY(i, yB);
                    GraphOfValues.Series[4].Points.AddXY(i, yB + Innacurate);
                }
                SkipFirst = false; ;
                GraphOfValues.Series[2].Points.AddXY(i, Convert.ToDouble(ConcentrationOfA.Value) - yA - yB);
                GraphOfValues.Series[5].Points.AddXY(i, Convert.ToDouble(ConcentrationOfA.Value) - yA - yB + Innacurate);
            }
        }
    }
}
