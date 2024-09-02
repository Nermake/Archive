using Mori.SDK.Zenject.Example.GameType;
using UnityEngine;
using Zenject;

namespace Mori.SDK.Zenject.Example.Installers
{
    public sealed class SceneInstaller : MonoInstaller
    {
        [SerializeField] private Character _character;

        public override void InstallBindings()
        {
            Container.Bind<ICharacter>().To<Character>().FromInstance(_character).AsSingle();
        }
    }
}