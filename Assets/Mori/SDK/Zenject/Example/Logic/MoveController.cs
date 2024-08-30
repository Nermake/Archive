using Mori.SDK.Zenject.Example.GameType;
using UnityEngine;
using Zenject;

namespace Mori.SDK.Zenject.Example.Logic
{
    public class MoveController : MonoBehaviour
    {
        [SerializeField] private MoveInput _moveInput;
        
        private ICharacter _character;

        [Inject]
        public void Construct(ICharacter character)
        {
            _character = character;
        }

        private void Update()
        {
            _character.Move(_moveInput.GetDirection(), Time.deltaTime);
        }
    }
}