using System;
using Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Message;
using UnityEngine;

namespace Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.View
{
    public class DebugDemo : MonoBehaviour
    {
        [SerializeField] private DebugToolkit _debugToolkit;

        private void Start()
        {
            PlayerData playerData = new PlayerData(100, Vector3.zero);
            
            _debugToolkit.Log(new GeneralDebugMessage("application started."));
            _debugToolkit.Log(new StateSaveMessage("player_state", playerData.ToString()));
            _debugToolkit.Log(null);
        }
    }

    [Serializable]
    public struct PlayerData
    {
        public int Health;
        public Vector3 Position;

        public PlayerData(int health, Vector3 position)
        {
            Health = health;
            Position = position;
        }

        public override string ToString()
        {
            return $"Health: {Health} | Position: {Position}";
        }
    }
}