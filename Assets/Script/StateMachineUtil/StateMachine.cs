using System;
using System.Linq;
using UnityEngine;

namespace Script.StateMachineUtil
{
    public class StateMachine : MonoBehaviour
    {
        private IState[] states;
        private IState current;

        private void Start()
        {
            states = new IState[transform.childCount];
            for (var i = 0; i < transform.childCount; i++)
            {
                states[i] = transform.GetChild(i).GetComponent<IState>();
            }
            current = states[0];
            ChangeState(states[0].Name);
        }

        public void ChangeState(string stateName)
        {
            var state = states.FirstOrDefault(s => s.Name == stateName);
            if (state == null) throw new Exception("Invalid state name");
            
            current.Exit();
            if (!state.Enter())
            {
                ResetStates();
                return;
            }
            current = state;
        }

        public void ResetStates()
        {
            ChangeState(states[0].Name);
        }
    }
}
