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
            // Define the final states for the divide by 3 automata
            var finalStates = new List<State> 
            {
                State.S0,
                State.S1,
                State.S2
            };

            // Create the transition table for the divide by 3 automata
            var finiteAutomaton = new FiniteAutomaton(State.S0, finalStates);
            CreateDivideBy3TransitionTable(finiteAutomaton);

            // Keep console window running
            while (true)
            {
                // Read in console input
                string input;
                Console.WriteLine("Enter binary input to be divided by 3: ");
                input = Console.ReadLine();

                // Process input and check if the result state is a final state
                var result = finiteAutomaton.ProcessInput(input);
                if (finiteAutomaton.IsCurrentStateAFinalState())
                {
                    Console.WriteLine("The remainder divided by 3 is: " + (int)finiteAutomaton.GetCurrentState());
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
                // Reset the automata after each process run
                finiteAutomaton.ResetState();
            }
        }

        private static void CreateDivideBy3TransitionTable(FiniteAutomaton finiteAutomaton)
        {
            if (finiteAutomaton == null)
            {
                return;
            }
            finiteAutomaton.CreateTransition(State.S0, 0, State.S0);
            finiteAutomaton.CreateTransition(State.S0, 1, State.S1);
            finiteAutomaton.CreateTransition(State.S1, 0, State.S2);
            finiteAutomaton.CreateTransition(State.S1, 1, State.S0);
            finiteAutomaton.CreateTransition(State.S2, 0, State.S1);
            finiteAutomaton.CreateTransition(State.S2, 1, State.S2);
        }
    }
}
