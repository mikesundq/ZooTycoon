using System;
using System.Collections.Generic;
using System.Text;
using Xunit;


namespace ZooTycoon.Tests
{
    public class TestPanda
    {

        [Theory]
        [InlineData(5, 10)]
        [InlineData(6, 12)]
        [InlineData(7, 12)]
        [InlineData(0, 0)]
        public void GetFoodNeededForPanda_TestPanda_CorrectSum(int ageOfPanda, double expectedFoodNeeded)
        {

            var testPanda = new Panda() { Age = ageOfPanda };

            var actualFoodNeeded = testPanda.Feed();
            
            Assert.Equal(expectedFoodNeeded, actualFoodNeeded);

        }



    }
}
