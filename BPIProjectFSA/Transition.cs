using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPIProjectFSA
{
    public class Transition
    {
        private State currentState;
        private int input;
        private State resultState;
        public Transition(State currentState, int input, State resultState)
        {
            this.currentState = currentState;
            this.input = input;
            this.resultState = resultState;
        }

        public State getCurrentState()
        {
            return currentState;
        }

        public State getResultState()
        {
            return resultState;
        }

        public int getInput()
        {
            return input;
        }
    }
}
