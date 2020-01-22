using System;
using System.Collections.Generic;
using System.Text;
using ZooTycoon.Interfaces;

namespace ZooTycoon
{
    public class Lion : Animal , ICanHunt
    {
        public override string GetAnimalType()
        {
            return "Lejon";
        }

    }
}
