using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPIProjectFSA
{
    // All the possible states of the Finite State Automata. States can be added here to extend the functionality to return the remainder of 4
    // (which would have 4 states), 5 (which would have 5 states), etc.
    public enum State
    {
        S0 = 0,
        S1 = 1,
        S2 = 2
    }
}
