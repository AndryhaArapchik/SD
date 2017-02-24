using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSD
{
    //Класс представляет свойства точки и основные мотеды работы с ней.
    //содержит так же перечень других точек,  с которыми даннаяя точка имеет связь.
    public class Points
    {
        public string Description { get; set; }
        public Guid Id { get; set; }
        public Coordinates Position { get; set; }
        public List<Points> ConnectingPoints { get; set; }
        public Points(int X, int Y, List<Points> ConnectingPoints, string Description)
        {
            this.Description = Description;
            Id = Guid.NewGuid();
            Position = new Coordinates(X, Y);
            this.ConnectingPoints = new List<Points>();
            if (ConnectingPoints != null)
            {
                foreach (Points item in ConnectingPoints)
                {
                    this.ConnectingPoints.Add(item);
                }
            }
        }
        public Points(int X, int Y) : this(X, Y, null, "none") { }
        public Points(int X, int Y, string Description) : this(X, Y, null, Description) { }
        public Points(string Description) : this(0, 0, null, Description) { }
        public Points() : this(0, 0, null, "none") { }

        //добовляет связь данной точки с другой
        public bool Connect(Points Point)
        {
            foreach (Points item in ConnectingPoints)
            {
                if (item.Id == Point.Id)
                {
                    return false;
                }
            }
            ConnectingPoints.Add(Point);
            return true;
        }
        //разъеденяет точки
        public bool Disconnect(Points Point)
        {
            foreach (Points item in ConnectingPoints)
            {
                if (item.Id == Point.Id)
                {
                    ConnectingPoints.Remove(item);
                    return true;
                }
            }
            return false;
        }
        //проверяет связанна ли точка с данной
        public bool SearchPoint(Points Point)
        {
            foreach (Points item in ConnectingPoints)
            {
                if (item.Id == Point.Id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
