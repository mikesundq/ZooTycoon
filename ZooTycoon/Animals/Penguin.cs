using System;
using System.Collections.Generic;
using System.Text;
using ZooTycoon.Interfaces;

namespace ZooTycoon.Animals
{
    public class Penguin : Animal , IEatable
    {
        public override string GetAnimalType()
        {
            return "Pingvin";
        }

       

    }
}
