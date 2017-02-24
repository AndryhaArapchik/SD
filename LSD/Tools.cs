using System;
using System.Collections.Generic;

namespace LSD
{
    //Класс представляет набор инструментов для поиска маршрута с заданными параметрами
    //Функционал позволяет:
    //-найти наименьший маршрут к точке от точки;
    //-найти все маршруты к точке от точки;
    //-найти наименьший маршрут к точке от точки, обойдя все существующие точки;
    //-найти наименьший маршрут к точке от точки, обойдя все существующие точки;
    //-найти наименьший маршрут к точке от точки, обойдя заданное количество точек;
    //-найти наименьший маршрут к точке от точки, обойдя заданное количество точек;
    //-вычислить матрицу расстояний;
    //-вычислить расстояние между точками.
    public class Tools
    {
        List<Route> AllRoutes = new List<Route>(); //содержит все пути решения
        Route TempRoute = new Route(); //содержит времменный путь и нужна только в рекурсивной функции SearchAllRoutes
        //посредством рекурсивного запуска производим поиск всех путей решения,
        //учитывая перечень точек, с которыми связанна начальная точка.
        //Поочередно рассматриваем каждую точку и с нею свзяанные, двигаясь по дереву до конечной
        //если конечная точка приводит к заданной конечной, то фиксируем данный путь, как верный в AllRoutes
        //иначе подымаемся на уровень назад и удаляем данную точку с текущего пути, т.к. никуда не приводит.
        void SearchAllRoutes(Points A, Points B)
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

        //производит поиск путей, которые приходят в заданную точку, пройдя через заданное количество точек
        public Route SearchMinimalPathWithSpecifiedPoints(Points A, Points B, List<Points> PointsList, int CountTransitPoints)
        {
            AllRoutes.Clear();
            TempRoute.TransitPointsList.Clear();
            Route Result = new Route();
            MatrixDistances M = CalcMatrixDistance(PointsList);
            SearchAllRoutes(A, B);

            foreach (Route item in AllRoutes)
            {
                if (item.TransitPointsList.Count == CountTransitPoints)
                {
                    Result = item;
                    break;
                }
            }
            
            foreach (Route item in AllRoutes)
            {
                item.CalcDistance(M);
                if (item.TransitPointsList.Count == CountTransitPoints)
                {
                    if (Result.Distance > item.Distance)
                    {
                        Result = item;
                    }
                }
            }

            return Result;
        }

        //производит поиск кратчайшего путя, который приходит в заданную точку, через заданное количество точек
        public List<Route> SearchPathsWithSpecifiedPoints(Points A, Points B, List<Points> PointsList, int CountTransitPoints)
        {
            AllRoutes.Clear();
            TempRoute.TransitPointsList.Clear();
            List<Route> Result = new List<Route>();
            MatrixDistances M = CalcMatrixDistance(PointsList);
            SearchAllRoutes(A, B);

            foreach (Route item in AllRoutes)
            {
                item.CalcDistance(M);
                if (item.TransitPointsList.Count == CountTransitPoints)
                {
                    Result.Add(item);
                }
            }

            return Result;
        }

        //производит поиск путей, которые приходят в заданную точку, пройдя через все остальные
        public Route SearchMinimalPathWithAllPoints(Points A, Points B, List<Points> PointsList)
        {
            return SearchMinimalPathWithSpecifiedPoints(A, B, PointsList, PointsList.Count);
        }

        //производит поиск кратчайшего путя, который приходит в заданную точку, пройдя через все остальные
        public List<Route> SearchPathsWithAllPoints(Points A, Points B, List<Points> PointsList)
        {
            return SearchPathsWithSpecifiedPoints(A, B, PointsList, PointsList.Count);
        }
        
        //производит поиск минимального маршрута к точке
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
                if (Result.Distance > item.Distance)
                {
                    Result = item;
                }
            }
            
            return Result;
        }

        //производит поиск всех маршрутов к заданной точке
        public List<Route> SearchPaths(Points A, Points B, List<Points> PointsList)
        {
            AllRoutes.Clear();
            TempRoute.TransitPointsList.Clear();
            List<Route> Result = new List<Route>();
            MatrixDistances M = CalcMatrixDistance(PointsList);
            SearchAllRoutes(A, B);

            foreach (Route item in AllRoutes)
            {
                item.CalcDistance(M);
                Result.Add(item);
            }

            return Result;
        }
        
        //Производится вычисление матрицы расстояний (содержит расстояние между всеми точками)
        public MatrixDistances CalcMatrixDistance(List<Points> PointsList)
        {
            MatrixDistances Result = new MatrixDistances(PointsList.Count);
            for (int i = 0; i < PointsList.Count; i++)
            {
                Result.IntPoint.Add(PointsList[i], i);
                for (int j = 0; j < PointsList.Count; j++)
                {
                    Result.Matrix[i, j] = GetDistance(PointsList[i], PointsList[j]);
                    Console.Write(Math.Round(Result.Matrix[i, j], 2).ToString() + '\t');
                }
                Console.WriteLine();
            }
            return Result;
        }

        //по формуле определяет расстояние между точками
        public double GetDistance(Points A, Points B)
        {
            double X = Math.Pow(B.Position.X - A.Position.X, 2);
            double Y = Math.Pow(B.Position.Y - A.Position.Y, 2);
            return Math.Sqrt(X + Y);
        }
    }
}
