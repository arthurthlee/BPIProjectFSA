using System;
using System.Collections.Generic;
using BPIProjectFSA;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace BPIProjectFSATests
{
    [TestClass]
    public class FSATest
    {
        
        [TestMethod]
        public void Check1010Returns1()
        {
            var finalStates = new List<State> 
            {
                State.S0,
                State.S1,
                State.S2
            };

            var finiteAutomaton = new FiniteAutomaton(State.S0, finalStates);
            finiteAutomaton.CreateTransition(State.S0, 0, State.S0);
            finiteAutomaton.CreateTransition(State.S0, 1, State.S1);
            finiteAutomaton.CreateTransition(State.S1, 0, State.S2);
            finiteAutomaton.CreateTransition(State.S1, 1, State.S0);
            finiteAutomaton.CreateTransition(State.S2, 0, State.S1);
            finiteAutomaton.CreateTransition(State.S2, 1, State.S2);

            var input = "1010";

            bool result = finiteAutomaton.ProcessInput(input);
            Assert.IsTrue(result);
            Assert.AreEqual(finiteAutomaton.GetCurrentState(), State.S1);
            finiteAutomaton.ResetState();
            Assert.AreEqual(finiteAutomaton.GetCurrentState(), State.S0);
        }

        [TestMethod]
        public void Check110Returns0()
        {
            var finalStates = new List<State> 
            {
                State.S0,
                State.S1,
                State.S2
            };

            var finiteAutomaton = new FiniteAutomaton(State.S0, finalStates);
            finiteAutomaton.CreateTransition(State.S0, 0, State.S0);
            finiteAutomaton.CreateTransition(State.S0, 1, State.S1);
            finiteAutomaton.CreateTransition(State.S1, 0, State.S2);
            finiteAutomaton.CreateTransition(State.S1, 1, State.S0);
            finiteAutomaton.CreateTransition(State.S2, 0, State.S1);
            finiteAutomaton.CreateTransition(State.S2, 1, State.S2);

            var input = "110";

            bool result = finiteAutomaton.ProcessInput(input);
            Assert.IsTrue(result);
            Assert.AreEqual(finiteAutomaton.GetCurrentState(), State.S0);
            finiteAutomaton.ResetState();
            Assert.AreEqual(finiteAutomaton.GetCurrentState(), State.S0);
        }

        [TestMethod]
        public void Check10Returns2()
        {
            var finalStates = new List<State> 
            {
                State.S0,
                State.S1,
                State.S2
            };

            var finiteAutomaton = new FiniteAutomaton(State.S0, finalStates);
            finiteAutomaton.CreateTransition(State.S0, 0, State.S0);
            finiteAutomaton.CreateTransition(State.S0, 1, State.S1);
            finiteAutomaton.CreateTransition(State.S1, 0, State.S2);
            finiteAutomaton.CreateTransition(State.S1, 1, State.S0);
            finiteAutomaton.CreateTransition(State.S2, 0, State.S1);
            finiteAutomaton.CreateTransition(State.S2, 1, State.S2);

            var input = "10";

            bool result = finiteAutomaton.ProcessInput(input);
            Assert.IsTrue(result);
            Assert.AreEqual(finiteAutomaton.GetCurrentState(), State.S2);
            finiteAutomaton.ResetState();
            Assert.AreEqual(finiteAutomaton.GetCurrentState(), State.S0);
        }

        [TestMethod]
        public void CheckResultStateNotFinal()
        {
            var finalStates = new List<State> 
            {
                State.S0,
            };

            var finiteAutomaton = new FiniteAutomaton(State.S0, finalStates);
            finiteAutomaton.CreateTransition(State.S0, 1, State.S1);

            var input = "1";

            bool result = finiteAutomaton.ProcessInput(input);
            Assert.IsFalse(result, "1 is not in the set of final states, therefore result should be false");
        }
    }
}
