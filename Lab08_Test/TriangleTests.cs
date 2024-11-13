using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mia_Lukashyk_Lab08;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab08_Test
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void Triangle_ctor()
        {
            Triangle triangle = new Triangle(new Point(1, 5), new Point(3, 6), new Point(9, 2));
            Assert.IsTrue(triangle.V2.X == 3 && triangle.V2.Y == 6);
        }
        private void CreateBadInstance()
        {
            Triangle triangle = new Triangle(new Point(1, 1), new Point(2, 2), new Point(3, 3));
        }
        [TestMethod]
        public void Triangle_ctor_exception_expected()
        {
            Assert.ThrowsException<ArgumentException>(CreateBadInstance);
        }
        [TestMethod]
        public void Triangle_P()
        {
            Triangle triangle = new Triangle();
            Assert.AreEqual(triangle.Perimeter(), 3 + 4 + 5);
        }
        [TestMethod]
        public void Triangle_Closest_Distance_To_Point()
        {
            Point p1 = new Point(1, 2);
            Triangle triangle = new Triangle(new Point(1, 1), new Point(0, 0), new Point(2, 0));
            Assert.AreEqual(triangle.ClosestDistanceToPoint(p1), 1);
        }
    }
}
