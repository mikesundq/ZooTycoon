using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ZooTycoon.Interfaces;
using ZooTycoon.Animals;


namespace ZooTycoon.Tests
{

    public class TestWombat
    {
        [Theory]
        [InlineData(5, 7)]
        [InlineData(6, 5.6)]
        [InlineData(7, 5.6)]
        [InlineData(0, 14)]
        public void GetFoodNeededForWombat_Weight14_CorrectSum(int ageOfWombat , double expectedFoodNeeded)
        {

            Wombat testWombat = new Wombat() { Age = ageOfWombat, Weight = 14 };

            double actualFoodNeeded = testWombat.Feed();

            Assert.Equal(expectedFoodNeeded, actualFoodNeeded , 4);

        }

    }
}
