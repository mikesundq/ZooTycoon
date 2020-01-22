using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZooTycoon.Animals;
using ZooTycoon.Interfaces;

namespace ZooTycoon
{
    public class UserInterface
    {
        public bool IsCreating { get; set; }
        public bool IsRunning { get; set; } = true;
        public AnimalCollection UserAnimalCollection { get; set; } = new AnimalCollection();

        public void Init()
        {
            UserAnimalCollection.Init();

            while (IsRunning)
            {
                ShowMainMenu();
            }
        }

        private void ShowMainMenu()
        {
            Console.Clear();

            Console.WriteLine("----ZooTycoon-----");
            Console.WriteLine("1) Se alla djuren");
            Console.WriteLine("2) Lägg till nytt djur");
            Console.WriteLine("3) Ny vecka");
            Console.WriteLine("0) Avsluta programmet");

            var menuInput = Console.ReadKey();

            switch (menuInput.KeyChar.ToString())
            {
                case "1":
                    ShowAllAnimals();
                    break;

                case "2":
                    CreateNewAnimalMenu();
                    break;

                case "3":
                    NewWeekPassing();
                    break;

                case "0":
                    IsRunning = false;
                    break;
            }

        }

        public void NewWeekPassing()
        {

            Console.Clear();

            if (UserAnimalCollection.IsTherePreyForHunters())
            {
                HuntersHuntPrey();
                var sumFoodNeeded = CalculateFoodNeeded();
                Console.Write($"Det kommer att gå åt {sumFoodNeeded}kg mat den här veckan");
            }
            else
            {
                Console.Write("Det finns inte tillräckligt med byten till dina jägare, skaffa fler bytesdjur...");
            }

            PressKeyToContinue();
        }

        public void HuntersHuntPrey()
        {
            string message = "";

            var listOfHunters = UserAnimalCollection.GetNameAndTypeListOfAllHunters();

            while (listOfHunters.Any())
            {
                message = TakePreyForHunter(listOfHunters , message);
            }

            Console.Write(message);

        }
        
        public string TakePreyForHunter(List<string> listOfHunters , string message)
        {

            message += $"{ listOfHunters.Last()} tog ";

            var indexList = UserAnimalCollection.GetIndexListOfEatableAnimals();

            var indexNr = UserAnimalCollection.GetRandomIndexNrFromIndexList(indexList.Count);

            var prey = UserAnimalCollection.GetAnimalByIndexNr(indexList[indexNr]);

            message += $"{prey.Name} ({prey.GetAnimalType()}){Environment.NewLine}";

            UserAnimalCollection.RemoveAnimalByIndexNr(indexList[indexNr]);

            listOfHunters.RemoveAt(listOfHunters.Count - 1);

            return message;
        }

        public double CalculateFoodNeeded()
        {
            double sumFoodNeeded = 0;

            foreach (var animal in UserAnimalCollection.GetAllAnimals())
            {
                if (animal is IFeedable feedable)
                {
                    sumFoodNeeded += feedable.Feed();
                }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;

            return sumFoodNeeded;
           
        }

        private void CreateNewAnimalMenu()
        {
            //AC.TestFunc();
            IsCreating = true;

            while (IsCreating)
            {
                Console.Clear();

                Console.WriteLine("--Vilket djur vill du lägga till--");
                Console.WriteLine("1) Lejon");
                Console.WriteLine("2) Panda");
                Console.WriteLine("3) Pingvin");
                Console.WriteLine("4) Wombat");
                Console.WriteLine("0) Avbryt");

                var menuInput = Console.ReadKey();

                switch (menuInput.KeyChar.ToString())
                {
                    case "1":
                        CreateNewLion();
                        break;

                    case "2":
                        CreateNewPanda();
                        break;

                    case "3":
                        CreateNewPenguin();
                        break;

                    case "4":
                        CreateNewWombat();
                        break;

                    case "0":
                        IsCreating = false;
                        break;
                }
            }


        }

        private void CreateNewWombat()
        {
            Wombat wombatToAdd = new Wombat();
            CreateNewAnimal(wombatToAdd);
        }

        private void CreateNewPenguin()
        {
            Penguin penguinToAdd = new Penguin();
            CreateNewAnimal(penguinToAdd);
        }

        private void CreateNewPanda()
        {
            Panda pandaToAdd = new Panda();
            CreateNewAnimal(pandaToAdd);
        }

        private void CreateNewLion()
        {
            Lion lionToAdd = new Lion();
            CreateNewAnimal(lionToAdd);
        }

        private void CreateNewAnimal(Animal animal)
        {
            animal.Name = GetNewName();
            animal.Age = GetNewAge();
            animal.Weight = GetNewWeight();

            UserAnimalCollection.AddAnimal(animal);

            IsCreating = false;
        }

        private int GetNewNumber()
        {
            int number = 0;
            try
            {
               number = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
               
            }
            //no negative numbers..
            if (number < 0)
            {
                number = 0;
            }

            return number;
        }

        private int GetNewWeight()
        {
            Console.Clear();
            Console.Write("Skriv in vikten: ");
            
            int weight = GetNewNumber();

            return weight;

        }

        private int GetNewAge()
        {
            Console.Clear();
            Console.Write("Skriv in ålder: ");

            int age = GetNewNumber();

            return age;
        }

        private string GetNewName()
        {
            Console.Clear();
            Console.Write("Skriv in namn: ");
            string name = Console.ReadLine();

            return name;
        }

        private void ShowAllAnimals()
        {
            Console.Clear();

            foreach (var animal in UserAnimalCollection.GetAllAnimals())
            {
                Console.WriteLine(
                    $"Typ: {animal.GetAnimalType(), -10} " +
                    $"Namn: {animal.Name, -15} " +
                    $"Ålder: {animal.Age, -5} " +
                    $"Vikt: {animal.Weight, -5}");
            }

            PressKeyToContinue();

        }

        private void PressKeyToContinue()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{Environment.NewLine}Tryck på valfri tangent för att fortsätta...");
            Console.ReadLine();
        }
    }
}
