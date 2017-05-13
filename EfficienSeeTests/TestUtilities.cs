using System;
using NUnit.Framework;

namespace EfficienSeeTests
{
    public static class TestUtilities
    {
        public static void AssertTwoDoublesAreCloseEnough(double expectedValue, double actualValue, double acceptableDifference = 1.0)
        {
            var closeEnough = AreTwoDoublesCloseEnough(expectedValue, actualValue, acceptableDifference);
            Assert.IsTrue(closeEnough, $"{expectedValue} is not close enough to {actualValue}");
        }

        public static void AssertTwoDoublesAreNotTooClose(double value1, double value2, double minimumDifference = 1.0)
        {
            var differentEnough = AreTwoDoublesDistantEnough(value1, value2, minimumDifference);
            Assert.IsTrue(differentEnough, $"{value1} is too close to {value2}");
        }

        public static bool AreTwoDoublesCloseEnough(double expectedValue, double actualValue, double acceptableDifference = 1.0)
        {
            double actualDifference = Math.Abs(expectedValue - actualValue);
            return actualDifference <= acceptableDifference;
        }

        public static bool AreTwoDoublesDistantEnough(double expectedValue, double actualValue, double minimumDifference = 1.0)
        {
            double actualDifference = Math.Abs(expectedValue - actualValue);
            return actualDifference >= minimumDifference;
        }
    }
}
