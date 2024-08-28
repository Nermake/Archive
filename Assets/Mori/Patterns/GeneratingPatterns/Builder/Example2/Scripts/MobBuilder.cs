using UnityEngine;

namespace Mori.Patterns.GeneratingPatterns.Builder.Example2
{
    public class MobBuilder
    {
        private Mob _prefab;
        private Skin _skinPrefab;
        private UnitStats _stats;
        private string _mobName;

        public MobBuilder WithRootPrefab(Mob prefab)
        {
            _prefab = prefab;

            return this;
        }
        
        public MobBuilder WithSkin(Skin skin)
        {
            _skinPrefab = skin;

            return this;
        }
        
        public MobBuilder WithStats(UnitStats stats)
        {
            _stats = stats;

            return this;
        }
        
        public MobBuilder WithName(string mobName)
        {
            _mobName = mobName;

            return this;
        }

        public Mob Build(Transform container = null)
        {
            var createMob = Object.Instantiate(_prefab, container);
            var createSkin = Object.Instantiate(_skinPrefab);
            
            createMob.SetSkin(createSkin);
            createMob.SetName(_mobName);
            createMob.SetStats(_stats);

            return createMob;
        }

        public MobBuilder Reset()
        {
            _prefab = null;
            _skinPrefab = null;
            _stats = null;
            _mobName = null;

            return this;
        }
    }
}