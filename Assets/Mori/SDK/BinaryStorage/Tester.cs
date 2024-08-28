using UnityEngine;

namespace Mori.SDK.BinaryStorage
{
    public class Tester : MonoBehaviour
    {
        private Storage _storage;
        //private Stats _stats;

        private void Start()
        {
            _storage = new Storage();
            //_stats = (Stats) _storage.Load(new Stats());
        }
    }
}