using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSD
{
    public class Tools
    {
        List<Route> AllRoutes = new List<Route>();
        Route TempRoute = new Route();
        public void SearchAllRoutes(Points A, Points B)
        {
            TempRoute.TransitPointsList.Add(A);
            foreach (Points item in A.ConnectingPoints)
            {
                if (item.Id == B.Id)
                {
                    TempRoute.TransitPointsList.Add(item);
                    Route T = new Route();

                    foreach (Points p in TempRoute.TransitPointsList)
                    {
                        T.TransitPointsList.Add(p);
                    }
                    AllRoutes.Add(T);
                    TempRoute.TransitPointsList.Remove(item);
                }
                else
                {
                    if (!TempRoute.TransitPointsList.Contains(item))
                    {
                        SearchAllRoutes(item, B);
                    }
                }
            }
            TempRoute.TransitPointsList.Remove(A);
        }
        public Route SearchMinimalPath(Points A, Points B, List<Points> PointsList)
        {
            AllRoutes.Clear();
            TempRoute.TransitPointsList.Clear();
            Route Result = new Route();
            MatrixDistances M = CalcMatrixDistance(PointsList);
            SearchAllRoutes(A, B);

            Result = AllRoutes[0];
            foreach (Route item in AllRoutes)
            {
                item.CalcDistance(M);
                // Console.WriteLine(item.ToString());
                if (Result.Distance > item.Distance)
                {
                    Result = item;
                }
            }
            
            return Result;
        }
        public MatrixDistances CalcMatrixDistance(List<Points> PointsList)
        {
            MatrixDistances Result = new MatrixDistances(PointsList.Count);
            for (int i = 0; i < PointsList.Count; i++)
            {
                Result.IntPoint.Add(PointsList[i], i);
                for (int j = 0; j < PointsList.Count; j++)
                {
                    Result.Matrix[i, j] = GetDistance(PointsList[i], PointsList[j]);
                }
            }
            return Result;
        }
        public double GetDistance(Points A, Points B)
        {
            double X = Math.Pow(B.Position.X - A.Position.X, 2);
            double Y = Math.Pow(B.Position.Y - A.Position.Y, 2);
            return Math.Sqrt(X + Y);
        }
    }
}
