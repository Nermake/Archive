using UnityEngine;

namespace Mori.Patterns.Fsm.Example.State
{
    public class FsmStateIdle : FsmState
    {
        public FsmStateIdle(Fsm fsm) : base(fsm) { }

        public override void Enter()
        {
            Debug.Log($"FsmStateIdle: Enter({GetType().Name})");
        }

        public override void Update()
        {
            Debug.Log($"FsmStateIdle: Update({GetType().Name})");

            if (Input.GetAxis("Horizontal") !=0f || Input.GetAxis("Vertical") != 0f)
            {
                Fsm.SetState<FsmStateWalk>();
            }
        }

        public override void Exit()
        {
            Debug.Log($"FsmStateIdle: Exit({GetType().Name})");
        }
    }
}