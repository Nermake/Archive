using UnityEngine;

namespace Mori.Patterns.GeneratingPatterns.Singleton.Example
{
    public class MainScript : MonoBehaviour
    {
        void Start()
        {
            Singleton.Instance.DoSomething();
        }
    }
}