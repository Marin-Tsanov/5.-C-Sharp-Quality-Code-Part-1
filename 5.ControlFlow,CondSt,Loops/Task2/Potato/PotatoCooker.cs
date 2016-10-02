using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Potato
{
    public class PotatoCooker
    {
        public bool CheckIfPotatoIsReadyForCooking(Potato potato)
        {

            if (potato != null)
            {
                if (potato.IsPilled && potato.IsNotRotten)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void Cook(Potato potato)
        {
            if (CheckIfPotatoIsReadyForCooking(potato))
            {
                potato.IsCooked = true;
            }
        }
    }
}