using UnityEngine;

namespace Mori.Patterns.Fsm.Example.State
{
    public class FsmStateMovement : FsmState
    {
        protected readonly Transform Transform;
        protected readonly float Speed;
        
        public FsmStateMovement(Fsm fsm, Transform transform, float speed) : base(fsm)
        {
            Transform = transform;
            Speed = speed;
        }
        
        public override void Enter()
        {
            Debug.Log($"FsmStateMovement: Enter({GetType().Name})");
        }

        public override void Update()
        {
            Debug.Log($"FsmStateMovement: Update({GetType().Name})");

            var inputDirection = ReadInput();
            if (inputDirection.sqrMagnitude == 0f)
            {
                Fsm.SetState<FsmStateIdle>();
            }
            
            Move(inputDirection);
        }
        
        public override void Exit()
        {
            Debug.Log($"FsmStateMovement: Exit({GetType().Name})");
        }

        protected Vector2 ReadInput()
        {
            var inputHorizontal = Input.GetAxis("Horizontal");
            var inputVertical = Input.GetAxis("Vertical");
            var inputDirection = new Vector2(inputHorizontal, inputVertical);

            return inputDirection;
        }

        protected virtual void Move(Vector2 inputDirection)
        {
            Transform.position += new Vector3(inputDirection.x, inputDirection.y, 0f) * (Speed * Time.deltaTime);
        }
    }
}