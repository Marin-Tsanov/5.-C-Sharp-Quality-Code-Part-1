using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _5.ControlFlow_CondSt_Loops.Contracts;

namespace _5.ControlFlow_CondSt_Loops.Models
{
    public abstract class Vegetable : IVegetable
    {
        public bool IsCutted { get; set; }

        public bool IsPeeled { get; set; }
    }
}