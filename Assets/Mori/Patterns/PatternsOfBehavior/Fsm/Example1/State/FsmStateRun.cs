using UnityEngine;

namespace Mori.Patterns.Fsm.Example.State
{
    public class FsmStateRun : FsmStateMovement
    {
        public FsmStateRun(Fsm fsm, Transform transform, float speed) : base(fsm, transform, speed) { }

        public override void Enter()
        {
            Debug.Log($"FsmStateRun: Enter({GetType().Name})");
        }

        public override void Update()
        {
            Debug.Log($"FsmStateRun: Update({GetType().Name})");
            
            var inputDirection = ReadInput();
            
            if (inputDirection.sqrMagnitude == 0f)
            {
                Fsm.SetState<FsmStateIdle>();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                Fsm.SetState<FsmStateWalk>();
            }
            
            Move(inputDirection);
        }

        public override void Exit()
        {
            Debug.Log($"FsmStateRun: Exit({GetType().Name})");
        }
    }
}