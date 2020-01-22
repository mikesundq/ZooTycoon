using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ZooTycoon.Animals;

namespace ZooTycoon.Tests
{
    public class TestAnimalCollection
    {
        ///////////////////////////////
        //create known list for testing
        //////////////////////////////
        private AnimalCollection StartTestWithListOfKnownAnimals()
        {
            var animalCollection = new AnimalCollection
            {
                Animals = GetTestListOfFourAnimals()
            };

            return animalCollection;
        }

        private List<Animal> GetTestListOfFourAnimals()
        {
            List<Animal> testListOfAnimals = new List<Animal>
            {
                new Lion() {Name = "Leo", Age = 2, Weight = 100},
                new Panda() {Name = "Snobben" , Age = 4 , Weight = 150},
                new Penguin() {Name = "Fracken", Age = 5, Weight = 10},
                new Wombat() {Name = "Gnagge", Age = 2, Weight = 20}
            };
            return testListOfAnimals;
        }
        /////////////////////////////////////
        //end of create known list for testing
        /////////////////////////////////////
        
        [Fact]
        public void GetRandomIndexNumberFromIndexList_ListOfFiveNr_LastIndex()
        {
            //I need to to this is a more fashionable way...
            var animalCollection = new AnimalCollection();
            animalCollection.TestState = true;
            var listOfNumbers = new List<int>()
            {
                5,2,13,6,8
            };

            var expectedNumber = 4;

            var actualNumber = animalCollection.GetRandomIndexNrFromIndexList(listOfNumbers.Count);

            Assert.Equal(expectedNumber, actualNumber);
        }


        [Fact]
        public void GetAllAnimals_ListOfKnownAnimals_ListCountFour()
        {

            var animalCollection = StartTestWithListOfKnownAnimals();

            var expectedCountNumber = 4;

            var animals = animalCollection.GetAllAnimals();

            var actualCountNumber = animals.Count;

            Assert.Equal(expectedCountNumber, actualCountNumber);

        }

        [Fact]
        public void AddAnimal_AddOneToKnownListAnimals_CountNumberFive()
        {
            var animalCollection = StartTestWithListOfKnownAnimals();
            animalCollection.AddAnimal(new Lion());

            var expectedCountNumber = 5;

            var actualCountNumber = animalCollection.Animals.Count;

            Assert.Equal(expectedCountNumber, actualCountNumber);

        }


        [Fact]
        public void GetIndexListOfEatableAnimals_KnownList_CorrectList()
        {
            var animalCollection = StartTestWithListOfKnownAnimals();

            List<int> expectedList = new List<int>
            {
                2,3
            };

            var actualList = animalCollection.GetIndexListOfEatableAnimals();

            Assert.Equal(expectedList, actualList);
        }


        [Fact]
        public void GetNameAndTypeListOfAllHunters_ListOfOneHunter_CorrectString()
        {
            var animalCollection = StartTestWithListOfKnownAnimals();

            var expectedList = new List<string>
            {
                "Leo (lejon)"
            };

            var actualList = animalCollection.GetNameAndTypeListOfAllHunters();

            Assert.Equal(expectedList, actualList);
        }


        [Theory]
        [InlineData(1, true)]
        [InlineData(2, true)]
        [InlineData(3, false)]
        public void IsTherePreyForHunters_ListOfMoreEqualLessPrey_CorrectBool(int listNumber, bool expectedBool)
        {

            var animalCollection = new AnimalCollection();

            switch (listNumber)
            {
                case 1:
                    animalCollection.Animals = GetListOfMorePrey();
                    break;
                case 2:
                    animalCollection.Animals = GetListOfEqualHunterPrey();
                    break;
                case 3:
                    animalCollection.Animals = GetListOfLessPrey();
                    break;
            }

            var actualBool = animalCollection.IsTherePreyForHunters();

            Assert.Equal(expectedBool, actualBool);
        }
        ///////////////////////////////////////////
        //Lists needed for test if there is enough prey
        //////////////////////////////////////////
        private List<Animal> GetListOfMorePrey()
        {
            List<Animal> animalListMorePrey = new List<Animal>
            {
                new Lion(),
                new Penguin(),
                new Penguin()
            };
            return animalListMorePrey;
        }

        private List<Animal> GetListOfEqualHunterPrey()
        {
            List<Animal> animalListEqualHunterPrey = new List<Animal>
            {
                new Lion(),
                new Penguin()
            };
            return animalListEqualHunterPrey;
        }
        private List<Animal> GetListOfLessPrey()
        {
            List<Animal> animalListOfLessPrey = new List<Animal>
            {
                new Lion(),
                new Lion(),
                new Penguin()
            };
            return animalListOfLessPrey;
        }
        ////////////////////////////////////////////
        //end of lists needed to see if there is prey
       ///////////////////////////////////////////



    }
}
