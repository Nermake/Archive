using UnityEngine;

namespace Mori.Patterns.AbstractFactory.Example
{
    public class GreenUnitsFactory : UnitsFactory
    {
        public override Knight CreateKnight()
        {
            var prefab = Resources.Load<GameObject>("Prefabs/knight_green");
            var go = GameObject.Instantiate(prefab);
            var knight = go.GetComponent<GreenKnight>();
            
            return knight;
        }

        public override Mage CreateMage()
        {
            var prefab = Resources.Load<GameObject>("Prefabs/mage_green");
            var go = GameObject.Instantiate(prefab);
            var mage = go.GetComponent<GreenMage>();
            
            return mage;
        }

        public override Archer CreateArcher()
        {
            var prefab = Resources.Load<GameObject>("Prefabs/archer_green");
            var go = GameObject.Instantiate(prefab);
            var archer = go.GetComponent<GreenArcher>();
            archer.Init(1.0f);
            
            return archer;
        }
    }
}