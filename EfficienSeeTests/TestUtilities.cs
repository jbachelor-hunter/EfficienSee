using System;
using NUnit.Framework;

namespace EfficienSeeTests
{
    public static class TestUtilities
    {
        public static void AssertTwoDoublesAreCloseEnough(double expectedValue, double actualValue, double acceptableDifference = 1.0)
        {
            double difference = Math.Abs(expectedValue - actualValue);
            Assert.IsTrue(difference <= acceptableDifference, $"{expectedValue} is not close enough to {actualValue}");
        }

        public static void AssertTwoDoublesAreNotTooClose(double expectedValue, double actualValue, double minimumDifference = 1.0)
        {
            double actualDifference = Math.Abs(expectedValue - actualValue);
            Assert.IsFalse(actualDifference <= minimumDifference, $"{expectedValue} is too close to {actualValue}");
        }
    }
}
