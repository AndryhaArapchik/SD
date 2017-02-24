using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSD
{
    public class Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Coordinates(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public Coordinates() : this(0, 0) { }
    }
}
