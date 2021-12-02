using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace Day1.Tests
{
    public class Tests
    {
        private SonarSweepAnalyser _analyser;

        [SetUp]
        public void Arrange()
        {
            _analyser = new SonarSweepAnalyser();
        }

        [Test]
        public void When_CountingDepthWithSinglePoint_Then_CountCorrectly()
        {
            var testCases = SetupSingleTestCases();

            foreach (var testCase in testCases)
            {
                var result = _analyser.GetDepthIncreasingCount(testCase.Scenario);

                result.Should().Be(testCase.ExpectedResult);
            }
        }

        [Test]
        public void When_CountingDepthWithGrouped_Then_CountCorrectly()
        {
            var testCases = SetupGroupedTestCases();

            foreach (var testCase in testCases)
            {
                var result = _analyser.GetRollingDepthIncreasingCount(testCase.Scenario);

                result.Should().Be(testCase.ExpectedResult);
            }
        }

        private List<TestCase> SetupSingleTestCases()
        {
            return new List<TestCase>
            {
                new TestCase(new List<int> { 0, 1, 2, 3 }, 3),
                new TestCase(new List<int> { 3, 2, 1, 0 }, 0),
                new TestCase(new List<int> { 1, 2, 1, 2 }, 2),
                new TestCase(new List<int>(), 0)
            };
        }

        private List<TestCase> SetupGroupedTestCases()
        {
            return new List<TestCase>
            {
                new TestCase(new List<int> { 0, 1, 2, 3, 4, 5, 6 }, 4),
                new TestCase(new List<int> { 6, 5, 4, 3, 2, 1, 0 }, 0),
                new TestCase(new List<int> { 1, 2, 3, 2, 1, 2, 3 }, 2),
                new TestCase(new List<int>(), 0)
            };
        }

        private class TestCase 
        {
            public List<int> Scenario { get; }
            public int ExpectedResult { get; }

            public TestCase(List<int> scenario, int expectedResult)
            {
                Scenario = scenario;
                ExpectedResult = expectedResult;
            }
        }
    }
}