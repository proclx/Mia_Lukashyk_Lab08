using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Mia_Lukashyk_Lab08;

namespace Lab08_Test
{
    [TestClass]
    public class PointTests
    {
        [TestMethod]
        public void Point_default_ctor()
        {
            Point p1 = new Point();
            Assert.IsTrue(p1.X == 0 && p1.Y == 0);
        }
        [TestMethod]
        public void Point_ctor()
        {
            Point p1 = new Point(1, 2);
            Assert.IsTrue(p1.X == 1 && p1.Y == 2);
        }
        [TestMethod]
        public void Point_distance_to_v1()
        {
            Point p1 = new Point();
            Point p2 = new Point(0, 1);
            Assert.AreEqual(p1.DistanceTo(p2), p2.DistanceTo(p1));
            Assert.AreEqual(p1.DistanceTo(p2), 1);
        }
        [TestMethod]
        public void Point_distance_to_v2()
        {
            Point p1 = new Point(1, 2);
            Point p2 = new Point(4, 6);
            Assert.AreEqual(p1.DistanceTo(p2), p2.DistanceTo(p1));
            Assert.AreEqual(p1.DistanceTo(p2), 5);
        }
    }
}
