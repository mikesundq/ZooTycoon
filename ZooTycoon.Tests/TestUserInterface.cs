using System;
using System.Collections.Generic;
using System.Text;
using ZooTycoon.Animals;
using Xunit;

namespace ZooTycoon.Tests
{
    public class TestUserInterface
    {

        /////////////////////////////////////////////////
        ///////Setup for known conditions
        ///////////////////////////////////////////////
        private UserInterface StartTestWithKnownConditions()
        {
            var userInterface = new UserInterface
            {
                UserAnimalCollection = new AnimalCollection
                {
                    Animals = GetTestListOfSixAnimals(),
                    TestState = true
                }
            };

            return userInterface;
        }

        private List<Animal> GetTestListOfSixAnimals()
        {
            List<Animal> testListOfAnimals = new List<Animal>
            {
                new Lion() {Name = "Leo", Age = 2, Weight = 100},
                new Lion() {Name = "Simba", Age = 2, Weight = 100},
                new Panda() {Name = "Snobben" , Age = 4 , Weight = 150},
                new Penguin() {Name = "Fracken", Age = 5, Weight = 10},
                new Wombat() {Name = "Gnagge", Age = 2, Weight = 20},
                new Wombat() {Name = "Putte", Age = 5, Weight = 14}
            };
            return testListOfAnimals;
        }
        /////////////////////////////////////////////////
        ///end of setup
        ////////////////////////////////////////////////

        [Fact]
        public void TakePreyForHunter_KnownConditions_CorrectString()
        {
            var userInterface = StartTestWithKnownConditions();

            var listOfHunters = new List<string>
            {
                "test1 (lejon)",
                "test2 (lejon)"
            };

            var expectedString = $"test2 (lejon) tog Putte (Wombat){Environment.NewLine}";

            var actualString = "";

            actualString =  userInterface.TakePreyForHunter(listOfHunters, actualString);

            Assert.Equal(expectedString, actualString);

        }

        [Fact]
        public void CalculateFoodNeeded_KnownConditions_CorrectDouble()
        {
            var userInterface = StartTestWithKnownConditions();

            var expectingDouble = 31;

            var actualDouble = userInterface.CalculateFoodNeeded();

            Assert.Equal(expectingDouble, actualDouble);
        }


    }
}
