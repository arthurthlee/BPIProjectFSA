using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPIProjectFSA
{
    class Program
    {
        static void Main(string[] args)
        {
            var state0 = new State("S0");
            var state1 = new State("S1");
            var state2 = new State("S2");

            var transition1 = new Transition(state0, 0, state0);
            var transition2 = new Transition(state0, 1, state1);
            var transition3 = new Transition(state1, 0, state2);
            var transition4 = new Transition(state1, 1, state0);
            var transition5 = new Transition(state2, 0, state1);
            var transition6 = new Transition(state2, 1, state2);

            var transitions = new List<Transition>();
            transitions.Add(transition1);
            transitions.Add(transition2);
            transitions.Add(transition3);
            transitions.Add(transition4);
            transitions.Add(transition5);
            transitions.Add(transition6);

            while (true)
            {
                string input;
                Console.WriteLine("Enter input: ");
                input = Console.ReadLine();
                bool result = false;

                var stateMachine = new StateMachine(state0, transitions);
                for (int index = 0; index < input.Length; index++)
                {
                    result = stateMachine.GetNextState((int)Char.GetNumericValue(input[index]));
                }
                if (result)
                {
                    Console.WriteLine("The result is: " + stateMachine.GetCurrentState().GetStateName());
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }
    }
}
