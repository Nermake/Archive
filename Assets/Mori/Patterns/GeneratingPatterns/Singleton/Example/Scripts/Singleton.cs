using UnityEngine;

namespace Mori.Patterns.GeneratingPatterns.Singleton.Example
{
    public class Singleton : MonoBehaviour
    {
        private static Singleton _instance;
        public static Singleton Instance => _instance;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void DoSomething()
        {
            Debug.Log("DoSomething");
        }
    }
}