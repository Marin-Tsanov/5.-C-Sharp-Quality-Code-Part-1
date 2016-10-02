using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.ControlFlow_CondSt_Loops.Contracts
{
    public interface IVegetable
    {
        bool IsPeeled { get; set; }

        bool IsCutted { get; set; }
    }
}
