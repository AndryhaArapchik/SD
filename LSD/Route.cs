using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSD
{
    //Класс реализует маршрут и все необходимые методы работы с ним.
    public class Route
    {
        public Guid Id { get; private set; }
        public double Distance { get; private set; }
        public List<Points> TransitPointsList { get; private set; }
        public Route()
        {
            Id = Guid.NewGuid();
            Distance = 0;
            TransitPointsList = new List<Points>();
        }
        public void CalcDistance(MatrixDistances M)
        {
            int prevPoint = 0;
            for (int nextPoint = 1; nextPoint < TransitPointsList.Count; nextPoint++)
            {
                int x = 0;
                M.IntPoint.TryGetValue(TransitPointsList[prevPoint], out x);
                int y = 0;
                M.IntPoint.TryGetValue(TransitPointsList[nextPoint], out y);
                Distance += M.Matrix[x, y];
                prevPoint++;
            }
        }
        public override string ToString()
        {
            string Result = string.Empty;
            Result = "Route id:\t" + Id.ToString() + ";\n";
            Result += "Transit points:\n";
            foreach (Points TP in TransitPointsList)
            {
                Result += "\t\tDescription: " + TP.Description + "\t(Id: " + TP.Id.ToString() + ";\n";
            }
            Result += '\n';
            Result += "Route distance:\t" + Distance + ".\n";
            return Result;
        }
    }
}
