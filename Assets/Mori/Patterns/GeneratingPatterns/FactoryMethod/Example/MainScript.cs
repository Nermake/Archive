using UnityEngine;

namespace Mori.Patterns.GeneratingPatterns.FactoryMethod.Example
{
    public class MainScript : MonoBehaviour
    {
        private Creator _fireCreator;
        private Creator _frostCreator;
        private void Start()
        {
            _fireCreator = new FireCreator();
            _frostCreator = new FrostCreator();
            
            Mage fireMage = _fireCreator.FactoryMethod();
            Debug.Log(fireMage);
            fireMage.CastSpell();

            Mage frostMage = _frostCreator.FactoryMethod();
            Debug.Log(frostMage);
            frostMage.CastSpell();
            
        }
    }
}