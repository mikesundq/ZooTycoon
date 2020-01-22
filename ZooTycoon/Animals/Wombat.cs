using System;
using System.Collections.Generic;
using System.Text;
using ZooTycoon.Interfaces;

namespace ZooTycoon.Animals
{
    public class Wombat : Animal , IEatable , IFeedable
    {
        public double Feed()
        {
            //return (5 / 10); //this returns 0!!!!! Check this later.....
            //I know why!! Trying to divide int with int -> rounded down to 0....

            return (Age > 6) ? Weight * 0.4 : Weight - (Weight * Age * 0.1);
        }

        public override string GetAnimalType()
        {
            return "Wombat";
        }
       
    }
}
