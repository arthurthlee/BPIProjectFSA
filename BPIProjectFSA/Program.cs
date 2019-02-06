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
            var finalStates = new List<State> 
            {
                State.S0,
                State.S1,
                State.S2
            };

            var stateMachine = new FiniteAutomaton(State.S0, finalStates);
            stateMachine.CreateTransition(State.S0, 0, State.S0);
            stateMachine.CreateTransition(State.S0, 1, State.S1);
            stateMachine.CreateTransition(State.S1, 0, State.S2);
            stateMachine.CreateTransition(State.S1, 1, State.S0);
            stateMachine.CreateTransition(State.S2, 0, State.S1);
            stateMachine.CreateTransition(State.S2, 1, State.S2);

            while (true)
            {
                string input;
                Console.WriteLine("Enter input: ");
                input = Console.ReadLine();
                var result = stateMachine.ProcessInput(input);
                if (stateMachine.IsCurrentStateAFinalState())
                {
                    Console.WriteLine("The result is: " + (int)stateMachine.GetCurrentState());
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
                stateMachine.ResetState();
            }
        }
    }
}
