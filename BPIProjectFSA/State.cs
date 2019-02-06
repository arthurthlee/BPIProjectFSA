using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPIProjectFSA
{
    public class State
    {
        string stateName;
        public State(string state) 
        {
            this.stateName = state;
        }

        public string GetStateName()
        {
            return stateName;
        }
    }
}
