﻿using UnityEngine;

namespace Mori.Patterns.PatternsOfBehavior.Visitor
{
    public class HtmlVisitor : IVisitor
    {
        public void VisitPersonAcc(Person acc)
        {
            string result = "<table><tr><td>Свойство<td><td>Значение</td></tr>";
            result += "<tr><td>Name<td><td>" + acc.Name + "</td></tr>";
            result += "<tr><td>Number<td><td>" + acc.Number + "</td></tr></table>";
            Debug.Log(result);
        }
 
        public void VisitCompanyAc(Company acc)
        {
            string result = "<table><tr><td>Свойство<td><td>Значение</td></tr>";
            result += "<tr><td>Name<td><td>" + acc.Name + "</td></tr>";
            result += "<tr><td>RegNumber<td><td>" + acc.RegNumber + "</td></tr>";
            result += "<tr><td>Number<td><td>" + acc.Number + "</td></tr></table>";
            Debug.Log(result);
        }
    }
}