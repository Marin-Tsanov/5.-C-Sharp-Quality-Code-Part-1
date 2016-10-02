using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
   public enum Sex
    {
        ultraBro,
        hotChick
    }

    public class Human
    {
        public Sex sex { get; set; }
        public string HumanName { get; set; }
        public int Age { get; set; }

        public void CreateHuman(int id)
        {
            Human newHuman = new Human();
            newHuman.Age = id;

            if (id % 2 == 0)
            {
                newHuman.HumanName = "TheBro";
                newHuman.sex = Sex.ultraBro;
            }
            else
            {
                newHuman.HumanName = "TheChick";
                newHuman.sex = Sex.hotChick;
            }
        }
    }
}
