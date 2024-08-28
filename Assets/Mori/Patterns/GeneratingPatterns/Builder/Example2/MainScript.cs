using UnityEngine;

namespace Mori.Patterns.GeneratingPatterns.Builder.Example2
{
    public class MainScript : MonoBehaviour
    {
        [SerializeField] private Mob _mobRootPrefab;
        [SerializeField] private Skin _skinOgrePrefab;
        [SerializeField] private Skin _skinHumanPrefab;
        
        private UnitStats _ogrStats = new UnitStats
        {
            HP = 10,
            Level = 1,
            Speed = 5f
        };
        
        private UnitStats _humanStats = new UnitStats
        {
            HP = 20,
            Level = 2,
            Speed = 10f
        };

        private void Start()
        {
            var mobBuilder = new MobBuilder();

            var createdOgr = mobBuilder
                .Reset()
                .WithRootPrefab(_mobRootPrefab)
                .WithName("Ogr")
                .WithStats(_ogrStats)
                .WithSkin(_skinOgrePrefab)
                .Build();
            
            var createdHuman = mobBuilder
                .Reset()
                .WithRootPrefab(_mobRootPrefab)
                .WithName("Human")
                .WithStats(_humanStats)
                .WithSkin(_skinHumanPrefab)
                .Build();
            
            Debug.Log(createdOgr);
            Debug.Log(createdHuman);
        }
    }
}