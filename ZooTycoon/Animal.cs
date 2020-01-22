using System;
using System.Collections.Generic;
using System.Text;

namespace ZooTycoon
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }

        public abstract string GetAnimalType();
    }
}
