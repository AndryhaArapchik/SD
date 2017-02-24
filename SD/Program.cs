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
            Tools Tool = new Tools(); //объект управления инструментами построения маршрута

            List<Points> PointsList = new List<Points>(); //список точек

            //далее производим инициализацию и заполнение данных точек рандомными значениями
            Random R = new Random();

            int CountPoints = 5; //количество точек
            int MaxValueCoord = 10; //количество ед. в координатной сетке

            //инициализация и заполнение данных точек
            for (int i = 0; i < CountPoints; i++)
            {
                int X = R.Next(0, MaxValueCoord);
                int Y = R.Next(0, MaxValueCoord);
                Points Point = new Points(X, Y, i.ToString());
                PointsList.Add(Point);
                Console.WriteLine("Points information:");
                Console.WriteLine(i + ". X: " + Point.Position.X + "; Y: " 
                    + Point.Position.Y + "; Id: " + Point.Id + ';');
            }
            //обеспечиваем связь каждой точки с каждой
            foreach (Points item in PointsList)
            {
                foreach (Points TP in PointsList)
                {
                    item.ConnectingPoints.Add(TP);
                }
            }

           
            List<Route> MinimalPath = Tool.SearchPathsWithAllPoints(PointsList[0], PointsList[3], PointsList);

            foreach (Route item in MinimalPath)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("\n" + Tool.SearchMinimalPathWithAllPoints(PointsList[0], PointsList[3], PointsList).ToString());

            Console.ReadKey();
        }
    }
}
