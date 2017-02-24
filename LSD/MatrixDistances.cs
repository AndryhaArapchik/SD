using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSD
{
    public class MatrixDistances
    {
        public double[,] Matrix;
        public int CountPoints { get; set; }
        public Dictionary<Points, int> IntPoint { get; set; }
        public MatrixDistances(int CountPoints)
        {
            this.CountPoints = CountPoints;
            IntPoint = new Dictionary<Points, int>();
            Matrix = new double[CountPoints, CountPoints];
            for (int x = 0; x < CountPoints; x++)
            {
                for (int y = 0; y < CountPoints; y++)
                {
                    Matrix[x, y] = 0;
                }
            }
        }

        public override string ToString()
        {
            string Result = " ";
            for (int i = 0; i < CountPoints; i++)
            {
                for (int j = 0; j < CountPoints; j++)
                {
                    Result += Matrix[i, j].ToString() + ' ';
                }
                Result += '\n';
            }
            return Result;
        }
    }
}
