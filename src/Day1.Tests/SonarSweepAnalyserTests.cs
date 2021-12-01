using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Day1.Tests
{
    public class Tests
    {
        [Test]
        public void When_CountingDepth_Then_CountCorrectly()
        {
            var testCases = SetupTestCases();

            var analyser = new SonarSweepAnalyser();

            foreach (var testCase in testCases)
            {
                var result = analyser.GetDepthIncreasingCount(testCase.Scenario);

                result.Should().Be(testCase.ExpectedResult);
            }
        }

        private List<TestCase> SetupTestCases()
        {
            return new List<TestCase>
            {
                new TestCase(new List<int> { 0, 1, 2, 3 }, 3),
                new TestCase(new List<int> { 3, 2, 1, 0 }, 0),
                new TestCase(new List<int> { 1, 2, 1, 2 }, 2),
                new TestCase(new List<int>(), 0)
            };
        }

        private class TestCase : Tuple<List<int>, int>
        {
            public TestCase(List<int> scenario, int expectedResult) : base(scenario, expectedResult) 
            { 
            }

            public List<int> Scenario { get { return Item1; } }
            public int ExpectedResult { get { return Item2; } }
        }
    }
}