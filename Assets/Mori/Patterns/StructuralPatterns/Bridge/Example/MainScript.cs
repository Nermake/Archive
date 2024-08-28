using UnityEngine;

namespace Mori.Patterns.StructuralPatterns.Bridge.Example
{
    public class MainScript : MonoBehaviour
    {
        void Start()
        {
            Programmer freelancer = new FreelanceProgrammer(new CPPLanguage());
            freelancer.DoWork();
            freelancer.EarnMoney();
            
            freelancer.Language = new CSharpLanguage();
            freelancer.DoWork();
            freelancer.EarnMoney();
        }
    }
}

