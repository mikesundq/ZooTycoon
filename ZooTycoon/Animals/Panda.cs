using System;
using System.Collections.Generic;
using System.Text;
using ZooTycoon.Interfaces;

namespace ZooTycoon
{
    public class Panda : Animal , IFeedable
    {
        public double Feed()
        {
            return (Age > 6) ? 12 : Age * 2;
        }

        public override string GetAnimalType()
        {
            return "Panda";
        }
        
    }
}
