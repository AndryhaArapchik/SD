using LSD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SD v1.0 \n23.02.2017");

            Tools Tool = new Tools();

            List<Points> PointsList = new List<Points>();

            Random R = new Random();
            for (int i = 0; i < 12; i++)
            {
                int X = R.Next(0, 100);
                int Y = R.Next(0, 100);
                Points Point = new Points(X, Y, i.ToString());
                PointsList.Add(Point);
                Console.WriteLine(i + ". X: " + Point.Position.X + "; Y: " 
                    + Point.Position.Y + "; Id: " + Point.Id + ';');
            }
            PointsList[0].ConnectingPoints.Add(PointsList[1]);
            PointsList[0].ConnectingPoints.Add(PointsList[4]);
            PointsList[0].ConnectingPoints.Add(PointsList[6]);

            PointsList[1].ConnectingPoints.Add(PointsList[0]);
            PointsList[1].ConnectingPoints.Add(PointsList[5]);
            PointsList[1].ConnectingPoints.Add(PointsList[2]);

            PointsList[2].ConnectingPoints.Add(PointsList[1]);
            PointsList[2].ConnectingPoints.Add(PointsList[9]);
            PointsList[2].ConnectingPoints.Add(PointsList[3]);

            PointsList[3].ConnectingPoints.Add(PointsList[2]);
            PointsList[3].ConnectingPoints.Add(PointsList[10]);

            PointsList[4].ConnectingPoints.Add(PointsList[0]);
            PointsList[4].ConnectingPoints.Add(PointsList[5]);
            PointsList[4].ConnectingPoints.Add(PointsList[11]);

            PointsList[5].ConnectingPoints.Add(PointsList[1]);
            PointsList[5].ConnectingPoints.Add(PointsList[4]);
            PointsList[5].ConnectingPoints.Add(PointsList[10]);

            PointsList[6].ConnectingPoints.Add(PointsList[0]);
            PointsList[6].ConnectingPoints.Add(PointsList[10]);

            PointsList[7].ConnectingPoints.Add(PointsList[11]);

            PointsList[8].ConnectingPoints.Add(PointsList[11]);

            PointsList[9].ConnectingPoints.Add(PointsList[2]);

            PointsList[10].ConnectingPoints.Add(PointsList[3]);
            PointsList[10].ConnectingPoints.Add(PointsList[6]);
            PointsList[10].ConnectingPoints.Add(PointsList[5]);

            PointsList[11].ConnectingPoints.Add(PointsList[7]);
            PointsList[11].ConnectingPoints.Add(PointsList[8]);
            PointsList[11].ConnectingPoints.Add(PointsList[4]);

            Console.WriteLine();

            Route MinimalPath = Tool.SearchMinimalPath(PointsList[0], PointsList[5], PointsList);

            Console.WriteLine(MinimalPath.ToString());
            Console.ReadKey();
        }
    }
}
