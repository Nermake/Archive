using Mori.Patterns.Fsm.Example.State;
using UnityEngine;

namespace Mori.Patterns.Fsm.Example
{
    public class MainScript : MonoBehaviour
    {
        private Fsm _fsm;
        private float _walkSpeed = 10f;
        private float _runSpeed = 20f;

        private void Start()
        {
            _fsm = new Fsm();
            
            _fsm.AddState(new FsmStateIdle(_fsm));
            _fsm.AddState(new FsmStateWalk(_fsm, transform, _walkSpeed));
            _fsm.AddState(new FsmStateRun(_fsm, transform, _runSpeed));
            
            _fsm.SetState<FsmStateIdle>();
        }

        private void Update()
        {
            _fsm.Update();
        }
    }
}