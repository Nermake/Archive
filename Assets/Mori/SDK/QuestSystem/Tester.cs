using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem
{
    public class Tester : MonoBehaviour
    {
        [SerializeField] private QuestController _questController;
        [SerializeField] private List<GoalImplementer> _goalImplementers;
        [SerializeField] private QuestConfig _quest1;
        [SerializeField] private QuestConfig _quest2;
        [SerializeField] private QuestConfig _quest3;

        private void Update()
        {
            T_AddQuestion();
            T_ClearQuestList();
            T_Implement();
        }

        private void T_AddQuestion()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _questController.AddQuestion(_quest1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _questController.AddQuestion(_quest2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _questController.AddQuestion(_quest3);
            }
        }

        private void T_ClearQuestList()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                _questController.ClearQuestList();
            }
        }

        private void T_Implement()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _goalImplementers[0].OnImplement(1);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                _goalImplementers[1].OnImplement(1);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                _goalImplementers[2].OnImplement(1);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                _goalImplementers[3].OnImplement(1);
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                _goalImplementers[4].OnImplement(1);
            }
        }
    }
}