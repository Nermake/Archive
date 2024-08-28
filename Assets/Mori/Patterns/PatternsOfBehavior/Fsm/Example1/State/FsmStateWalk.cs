using UnityEngine;

namespace Mori.Patterns.Fsm.Example.State
{
    public class FsmStateWalk : FsmStateMovement
    {
        public FsmStateWalk(Fsm fsm, Transform transform, float speed) : base(fsm, transform, speed) { }

        public override void Enter()
        {
            Debug.Log($"FsmStateWalk: Enter({GetType().Name})");
        }

        public override void Update()
        {
            Debug.Log($"FsmStateWalk: Update({GetType().Name})");
            
            var inputDirection = ReadInput();
            
            if (inputDirection.sqrMagnitude == 0f)
            {
                Fsm.SetState<FsmStateIdle>();
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Fsm.SetState<FsmStateRun>();
            }
            
            Move(inputDirection);
        }

        public override void Exit()
        {
            Debug.Log($"FsmStateWalk: Exit({GetType().Name})");
        }
    }
}