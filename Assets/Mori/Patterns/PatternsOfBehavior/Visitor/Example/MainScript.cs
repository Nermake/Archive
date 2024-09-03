using System;
using UnityEngine;

namespace Mori.Patterns.PatternsOfBehavior.Visitor
{
    public class MainScript : MonoBehaviour
    {
        private Bank _bank;


        private void Start()
        {
            _bank = new Bank();
            
            _bank.Add(new Person { Name = "Иван Алексеев", Number = "82184931" });
            _bank.Add(new Company { Name="Microsoft", RegNumber="ewuir32141324", Number="3424131445"});
            
            _bank.Accept(new HtmlVisitor());
            _bank.Accept(new XmlVisitor());
        }
    }
}