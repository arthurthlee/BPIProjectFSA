using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPIProjectFSA
{
    public class StateMachine
    {
        List<Transition> transitions;
        State currentState;

        public StateMachine(State start, List<Transition> transitions)
        {
            this.currentState = start;
            this.transitions = transitions;
        }

        public bool GetNextState(int input)
        {
            foreach (var transition in transitions)
            {
                bool currentStateMatches = transition.getCurrentState() == currentState;
                bool inputMatches = transition.getInput() == input;
                if (currentStateMatches && inputMatches)
                {
                    currentState = transition.getResultState();
                    return true;
                }
            }
            return false;
        }

        public State GetCurrentState()
        {
            return currentState;
        }

    }
}
