﻿namespace Mori.Patterns.StructuralPatterns.EventBus.Example.Signals
{
    public class AddGoldSignal
    {
        public readonly int Value;

        public AddGoldSignal(int value)
        {
            Value = value;
        }
    }
}