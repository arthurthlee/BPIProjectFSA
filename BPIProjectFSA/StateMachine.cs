using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPIProjectFSA
{
    public class FiniteAutomaton
    {
        Dictionary<Tuple<State, int>, State> transitions = new Dictionary<Tuple<State,int>,State>();
        List<State> finalStates;
        State currentState;
        State startState;

        public FiniteAutomaton(State start, List<State> finalStates)
        {
            this.startState = start;
            this.currentState = start;
            this.finalStates = finalStates;
        }

        // By storing the transitions as a dictionary, we can optimize the runtime of getting the next state to be constant O(1).
        // This is better than if we stored the transitions in a list and iterated through the list to find a matching transition for the current state and input O(N).
        public State GetNextState(int input)
        {
            var transition = Tuple.Create(currentState, input);
            if (transitions.ContainsKey(transition))
            {
                currentState = transitions[transition];
            }
            return currentState;
        }

        public State ProcessInput(string input)
        {
            State result = currentState;
            for (int index = 0; index < input.Length; index++)
            {
                // This is under the assumption that the inputs will only be 1s and 0s, provided this FSA's only purpose is dividing a number.
                result = GetNextState((int)Char.GetNumericValue(input[index]));
            }
            return result;
        }

        public State GetCurrentState()
        {
            return currentState;
        }

        public bool IsCurrentStateAFinalState()
        {
            return finalStates.Contains(currentState);
        }

        public void ResetState()
        {
            currentState = startState;
        }

        public void CreateTransition(State state, int input, State resultState)
        {
            transitions.Add(Tuple.Create(state, input), resultState);
        }
    }
}
