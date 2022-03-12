using Microsoft.VisualStudio.TestTools.UnitTesting;
using Primes13;
using System;
using System.Collections.Generic;
using System.Text;

namespace Primes13.Tests
{
    [TestClass()]
    public class MainWindowTests
    {
        Dictionary<int, string> resultsConversion = new Dictionary<int, string>()
        {
            { 0, "0" },
            { 1, "1" },
            { 2, "2" },
            { 3, "3" },
            { 4, "4" },
            { 5, "5" },
            { 6, "6" },
            { 7, "7" },
            { 8, "8" },
            { 9, "9" },
            { 10, "A" },
            { 11, "B" },
            { 12, "C" },
            { 13, "10" },
            { 23, "1A" },
            { 67, "52" },
            { 1234, "73C" }
        };
        [TestMethod()]
        public void ConvertBase10ToBase13Test()
        {
            foreach (var test in resultsConversion)
            {
                string result = MainWindow.ConvertBase10ToBase13(test.Key);
                string expected = test.Value;
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod()]
        public void ConvertBase13toBase10Test()
        {
            foreach (var test in resultsConversion)
            {
                int result = MainWindow.ConvertBase13ToBase10(test.Value);
                int expected = test.Key;
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod()]
        public void GetFirstNPrimesTest()
        {
            Dictionary<int, int> results = new Dictionary<int, int>()
            {
                {1, 2},
                {2, 3},
                {3, 5},
                {4, 7},
                {5, 11},
                {6, 13},
                {100, 541},
                {1000, 7919}
            };
            foreach (var test in results)
            {
                int expected = test.Value;
                var result = MainWindow.GetFirstNPrimes(test.Key);
                int testedValue = result[result.Count - 1];
                Assert.AreEqual(expected, testedValue);
            }
        }

    }
}