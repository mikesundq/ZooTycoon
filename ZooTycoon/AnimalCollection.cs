using System;
using System.Collections.Generic;
using System.Text;
using ZooTycoon.Interfaces;
using System.Linq;
using System.Reflection;
using ZooTycoon.Animals;

namespace ZooTycoon
{
    public class AnimalCollection
    {
        public List<Animal> Animals { get; set; } = new List<Animal>();
        //probebly not the right way to solve testing but good for now...
        public bool TestState { get; set; } = false;

        public void Init()
        {
            Create10Animals();
        }

        public List<Animal> GetAllAnimals()
        {
            return Animals;
        }

        public void AddAnimal(Animal animal)
        {
            Animals.Add(animal);
        }

        public Animal GetAnimalByIndexNr(int index)
        {
            return Animals[index];
        }

        public void RemoveAnimalByIndexNr(int index)
        {
            Animals.RemoveAt(index);
        }

        public List<string> GetNameAndTypeListOfAllHunters()
        {
            List<string> nameTypeOfAllHunters = new List<string>();

            foreach (var animal in Animals)
            {
                if (animal is ICanHunt)
                {
                    nameTypeOfAllHunters.Add($"{animal.Name} ({animal.GetAnimalType().ToLower()})");
                }
            }

            return nameTypeOfAllHunters;
        }

        public List<int> GetIndexListOfEatableAnimals()
        {
            List<int> indexList = new List<int>();

            for (int i = 0; i < Animals.Count; i++)
            {
                if (Animals[i] is IEatable)
                {
                    indexList.Add(i);
                }
            }
            return indexList;
        }

        public int GetRandomIndexNrFromIndexList(int maxValue)
        {
            Random rand = new Random();
            return (TestState) ? maxValue - 1 : rand.Next(0, maxValue);
        }

        public bool IsTherePreyForHunters()
        {
            var hunters = Animals.Where(a => a is ICanHunt);
            var prey = Animals.Where(a => a is IEatable);

            return hunters.Count() <= prey.Count();
        }

        /// <summary>
        /// some test for getting all inherited classes of animal....
        /// https://stackoverflow.com/questions/5411694/get-all-inherited-classes-of-an-abstract-class
        /// </summary>
        public void TestFunc()
        {
            Console.Clear();

            Dictionary<string, Type> types = new System.Collections.Generic.Dictionary<string, Type>();

            foreach (Type type in Assembly.GetAssembly(typeof(Animal)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Animal))))
            {
                types.Add(type.Name, type);  //Console.WriteLine(Activator.CreateInstance(type));
            }
            Console.ReadLine();
        }

        private void Create10Animals()
        {
            Lion lionToAdd = new Lion
            {
                Name = "Leo",
                Age = 3,
                Weight = 150
            };

            Animals.Add(lionToAdd);

            Panda pandaToAdd = new Panda
            {
                Name = "Snobben",
                Age = 4,
                Weight = 250
            };

            Animals.Add(pandaToAdd);

            pandaToAdd = new Panda
            {
                Name = "KungFuPanda",
                Age = 2,
                Weight = 100
            };

            Animals.Add(pandaToAdd);

            Penguin penguinToAdd = new Penguin
            {
                Name = "Fracken",
                Age = 2,
                Weight = 20
            };

            Animals.Add(penguinToAdd);

            penguinToAdd = new Penguin
            {
                Name = "Näbben",
                Age = 6,
                Weight = 35
            };

            Animals.Add(penguinToAdd);

            penguinToAdd = new Penguin
            {
                Name = "Stinky",
                Age = 3,
                Weight = 45
            };

            Animals.Add(penguinToAdd);

            Wombat wombatToAdd = new Wombat
            {
                Name = "Gnagis",
                Age = 5,
                Weight = 14
            };

            Animals.Add(wombatToAdd);

            wombatToAdd = new Wombat
            {
                Name = "Sten",
                Age = 2,
                Weight = 11
            };

            Animals.Add(wombatToAdd);

            wombatToAdd = new Wombat
            {
                Name = "Nafsen",
                Age = 3,
                Weight = 12
            };

            Animals.Add(wombatToAdd);

            wombatToAdd = new Wombat
            {
                Name = "Svarten",
                Age = 4,
                Weight = 16
            };

            Animals.Add(wombatToAdd);

        }
    }
}
