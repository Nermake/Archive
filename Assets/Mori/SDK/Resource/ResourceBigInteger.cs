using System;
using System.Numerics;

namespace Mori.SDK.Resource
{
    public class ResourceBigInteger : IResource<BigInteger>
    {
        private BigInteger _amount;
        
        public event Action<BigInteger, BigInteger> Changed;
        
        public ResourceType Type { get; }

        public BigInteger Amount
        {
            get => _amount;
            set
            {
                var oldValue = _amount;
                _amount = value;
                
                if (oldValue != _amount) Changed?.Invoke(oldValue, _amount);
            }
        }

        public ResourceBigInteger(ResourceType type, BigInteger amountByDefault = default)
        {
            Type = type;
            Amount = amountByDefault;
        }
    }
}