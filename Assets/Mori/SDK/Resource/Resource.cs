using System;

namespace Mori.SDK.Resource
{
    public class Resource : IResource<int>
    {
        private int _amount;
        
        public event Action<int, int> Changed;
        
        public ResourceType Type { get; }

        public int Amount
        {
            get => _amount;
            set
            {
                var oldValue = _amount;
                _amount = value;
                
                if (oldValue != _amount) Changed?.Invoke(oldValue, _amount);
            }
        }

        public Resource(ResourceType type, int amountByDefault = default)
        {
            Type = type;
            Amount = amountByDefault;
        }
    }
}