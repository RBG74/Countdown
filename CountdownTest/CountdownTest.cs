using System.Collections.Generic;
using Countdown;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CountdownTest
{
    [TestClass]
    public class CountdownTest
    {
        [TestMethod]
        public void Case01()
        {
            var values = new List<int> { 7, 4, 5, 8, 3, 1 };
            int target = 299;
            Assert.IsTrue(Program.Resolve(target, values));
        }

        [TestMethod]
        public void Case02()
        {
            var values = new List<int> { 100, 75, 7, 9, 3, 6 };
            int target = 641;
            Assert.IsTrue(Program.Resolve(target, values));
        }

        [TestMethod]
        public void Case03()
        {
            var values = new List<int> { 100, 5};
            int target = 1000;
            Assert.IsFalse(Program.Resolve(target, values));
        }

        [TestMethod]
        public void Case04()
        {
            var values = new List<int> { 50, 8, 1, 8, 3, 7 };
            int target = 394;
            Assert.IsTrue(Program.Resolve(target, values));
        }

        [TestMethod]
        public void Case05()
        {
            var values = new List<int> { 25, 50, 100, 4, 9, 10 };
            int target = 909;
            Assert.IsTrue(Program.Resolve(target, values));
        }

        [TestMethod]
        public void Case06()
        {
            var values = new List<int> { 100, 7, 5, 4, 9, 7 };
            int target = 878;
            Assert.IsTrue(Program.Resolve(target, values));
        }

        [TestMethod]
        public void Case07()
        {
            var values = new List<int> { 75, 100, 25, 50, 10, 2 };
            int target = 971;
            Assert.IsFalse(Program.Resolve(target, values));
        }
    }
}
