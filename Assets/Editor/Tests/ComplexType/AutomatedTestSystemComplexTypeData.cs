using System.Collections.Generic;
using AutomatedTestSystem;
using NUnit.Framework;

namespace AutomatedTestSystemTests
{
    public class AutomatedTestSystemComplexTypeData
    {
        public static TestCaseData[] Testing()
        {
            var array = AutomatedTest.Populate<int[]>();
            var list = AutomatedTest.Populate<List<int>>();
            var dictionary = AutomatedTest.Populate<Dictionary<int, int>>();
            return new[]
            {
                new TestCaseData()
            };
        }
    }
}