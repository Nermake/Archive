using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mori.Patterns.StructuralPatterns.Composite.Example
{
    public class Directory : Component
    {
        private List<Component> components = new List<Component>();
 
        public Directory(string name) : base(name) { }
 
        public override void Add(Component component)
        {
            components.Add(component);
        }
 
        public override void Remove(Component component)
        {
            components.Remove(component);
        }
 
        public override void Print()
        {
            Debug.Log("Узел " + name);
            Debug.Log("Подузлы:");
            
            for(int i=0; i<components.Count;i++)
            {
                components[i].Print();
            }
        }
    }
}