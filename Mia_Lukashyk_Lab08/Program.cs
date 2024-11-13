using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mia_Lukashyk_Lab08
{
    public struct Point
    {
        public Point(double x = 0, double y = 0)
        {
            X = x; 
            Y = y;
        }
        public double X { get; set; }
        public double Y { get; set; }
        public override string ToString()
        {
            return $"({X}; {Y})";
        }
        public double DistanceTo(Point other)
        {
            double distance = Math.Sqrt((X - other.X) * (X - other.X) + (Y - other.Y) * (Y - other.Y));
            return distance;
        }
    }
    public class Triangle
    {
        private bool OnTheSameLine(Point p1, Point p2, Point p3)
        {
            bool result = (p2.X - p1.X) * (p3.Y - p1.Y) == (p2.Y - p1.Y) * (p3.X - p1.X);
            return result;
        }
        public Point V1 { get; }
        public Point V2 { get; }
        public Point V3 { get; }
        public Triangle() 
            : this(new Point(0, 0), new Point(0, 4), new Point(3, 0))
        {
        }
        public Triangle(Point v1, Point v2, Point v3)
        {
            if(OnTheSameLine(v1, v2, v3))
            {
                throw new ArgumentException($"Points are on the same line [{v1}; {v2}; {v3}]");
            }
            V1 = v1;
            V2 = v2;
            V3 = v3;
        }
        public double Perimeter()
        {
            double P = V1.DistanceTo(V2) + V1.DistanceTo(V3) + V2.DistanceTo(V3);
            return P;
        }
        public void Square<T>(T arg)
        {
            throw new NotImplementedException();
        }
        public void Print()
        {
            Console.WriteLine($"[{V1}; {V2}; {V3}]");
        }
        public double ClosestDistanceToPoint(Point p)
        {
            Point[] points = new Point[] { V2, V3 };
            Point min = V1;
            for (int i = 0; i < points.Length; ++i)
            {
                if(min.DistanceTo(p) > points[i].DistanceTo(p))
                {
                    min = points[i];
                }
            }
            double minDistance = min.DistanceTo(p);
            return minDistance;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point();
            Console.WriteLine(p1.Y);
            Triangle[] triangles = new Triangle[] {
                new Triangle(new Point(1, 1), new Point(2, 2), new Point(3, 4)),
                new Triangle(new Point(1, 5), new Point(3, 6), new Point(9, 2)),
                new Triangle(new Point(0.5, 1), new Point(2, 3), new Point(1, 2))
            };
            foreach (Triangle triangle in triangles)
            {
                triangle.Print();
            }
            Triangle closestToZero = triangles[0];
            Point zero = new Point(0, 0);
            foreach (Triangle triangle in triangles)
            {
                if(closestToZero.ClosestDistanceToPoint(zero) > triangle.ClosestDistanceToPoint(zero))
                {
                    closestToZero = triangle;
                }
            }
            Console.WriteLine($"Closest to {zero}:");
            closestToZero.Print();
        }
    }
}
