using UnityEngine;

namespace Mori.Patterns.StructuralPatterns.Proxy.Example
{
    public class MainScript : MonoBehaviour
    {
        private ICharacterStatsData _characterStatsData;

        private void Awake()
        {
            var origin = new CharacterStatsData();
            var proxy = new CharacterStatsDataProxy(origin);
            
            _characterStatsData = proxy;

            proxy.HealthChanged += health =>
            {
                Debug.Log("Proxy health " + health);
                var json = JsonUtility.ToJson(origin);
                Debug.Log(json);
            };
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var rHealth = Random.Range(-100, 100);
                _characterStatsData.Health = rHealth;
                
                _characterStatsData.DoSomething();
            }
        }
    }
}