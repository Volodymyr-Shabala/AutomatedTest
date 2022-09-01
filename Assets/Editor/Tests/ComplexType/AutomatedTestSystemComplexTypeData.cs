using System.Collections.Generic;
using AutomatedTestSystem;
using NUnit.Framework;

namespace AutomatedTestSystemTests
{
    public class AutomatedTestSystemComplexTypeData
    {
        public static IEnumerable<TestCaseData> Testing()
        {
            var array = AutomatedTest.Populate(typeof(int[]));
            var list = AutomatedTest.Populate(typeof(List<int[]>));
            var dictionary = AutomatedTest.Populate(typeof(Dictionary<int[], int[]>));
            return new[]
            {
                new TestCaseData()
            };
        }
    }
}